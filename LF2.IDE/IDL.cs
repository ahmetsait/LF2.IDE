using System.Runtime.InteropServices;

namespace LF2.IDE
{
	public class IDL
	{
		[DllImport("InstantDataModifier.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public static extern int InstantDataLoader(string data, int procId, int objId, int datType);
	}
}
