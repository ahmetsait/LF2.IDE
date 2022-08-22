using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using LF2;

namespace LF2.IDE
{
	public enum MsgType : byte
	{
		Info,
		Warning,
		Error,
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public delegate void Logger(
		[MarshalAs(UnmanagedType.LPStr)]
		string msg,
		[MarshalAs(UnmanagedType.LPStr)]
		string title,
		MsgType msgType);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public unsafe delegate void Dealloc(void* ptr);

	internal static class IDL
	{
		[DllImport("IDL.dll", EntryPoint = "instantLoad", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		static extern int InstantLoad(
			[MarshalAs(UnmanagedType.LPStr)]
			string data,
			int dataLength,
			int procId,
			DataType dataType,
			int datId,
			ObjectType objType,
			IntPtr hMainWindow,
			[MarshalAs(UnmanagedType.FunctionPtr)]
			Logger logFunc);

		public static int InstantLoad(
			[MarshalAs(UnmanagedType.LPStr)]
			string data,
			int procId,
			DataType dataType,
			int datId,
			ObjectType objType,
			IntPtr hMainWindow,
			Logger logFunc)
		{
			return InstantLoad(data, data.Length, procId, dataType, datId, objType, hMainWindow, logFunc);
		}

		// I would convert this to C# but we don't have proper Span<T> & Memory<T> support in .Net 4.6
		[DllImport("IDL.dll", EntryPoint = "readDataTxt", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		static extern unsafe int ReadDataTxt(
			[MarshalAs(UnmanagedType.LPStr)]
			string dataTxtContent,
			int dataTxtLength,
			out ObjectDataRaw* objects,
			out int objCount,
			out BackgroundDataRaw* backgrounds,
			out int bgCount,
			[MarshalAs(UnmanagedType.FunctionPtr)]
			out Dealloc dealloc,
			IntPtr hMainWindow);

		public unsafe static int ReadDataTxt(
			string dataTxtContent,
			out ObjectData[] objects,
			out BackgroundData[] backgrounds,
			IntPtr hMainWindow)
		{
			int result = ReadDataTxt(
				dataTxtContent,
				dataTxtContent.Length,
				out ObjectDataRaw* objectsRaw,
				out int objCount,
				out BackgroundDataRaw* backgroundsRaw,
				out int bgCount,
				out Dealloc dealloc,
				hMainWindow);
			
			if (result == 0)
			{
				objects = new ObjectData[objCount];
				for (int i = 0; i < objCount; i++)
				{
					objects[i].id = objectsRaw[i].id;
					objects[i].type = objectsRaw[i].type;
					objects[i].file = Encoding.ASCII.GetString(objectsRaw[i].file, objectsRaw[i].fileLength);
				}
				dealloc(objectsRaw);

				backgrounds = new BackgroundData[bgCount];
				for (int i = 0; i < bgCount; i++)
				{
					backgrounds[i].id = backgroundsRaw[i].id;
					backgrounds[i].file = Encoding.ASCII.GetString(backgroundsRaw[i].file, backgroundsRaw[i].fileLength);
				}
				dealloc(backgroundsRaw);
			}
			else
			{
				objects = null;
				backgrounds = null;
			}

			return result;
		}
	}

	public struct ObjectData
	{
		public int id;
		public ObjectType type;
		public string file;
	}

	public struct BackgroundData
	{
		public int id;
		public string file;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct ObjectDataRaw
	{
		public int id;
		public ObjectType type;
		public byte* file;
		public int fileLength;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe struct BackgroundDataRaw
	{
		public int id;
		public byte* file;
		public int fileLength;
	}

	// Not directly used in interop calls
	public struct DataTxt
	{
		public ObjectData[] objects;
		public BackgroundData[] backgrounds;
	}
}
