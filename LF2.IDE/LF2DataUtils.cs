using System;
using System.Text;
using System.IO;

namespace LF2.IDE
{
	public interface IDataUtil
	{
		string Decrypt(string filepath);
		void Encrypt(string filepath, string text);
	}

	public static class LF2DataUtil
	{
		public static string encryptionKey { get { return Settings.Default.encryptionKey; } }
		public static string decryptionKey { get { return Settings.Default.decryptionKey; } }

		public static string Decrypt(string filepath)
		{
			if (!string.IsNullOrEmpty(Settings.Default.dataUtil) && UtilManager.Utils != null)
				return UtilManager.ActiveUtil.Decrypt(filepath);

			byte[] buffer = File.ReadAllBytes(filepath);
			byte[] decryptedtext = new byte[buffer.Length];
			string password = encryptionKey;

			if (string.IsNullOrEmpty(password)) return Encoding.Default.GetString(buffer);

			for (int i = 123, j = 0; i < buffer.Length; i++, j++)
				decryptedtext[j] = (byte)(buffer[i] - (byte)password[j % password.Length]);

			return Encoding.Default.GetString(decryptedtext);
		}

		public static unsafe string DecryptUnsafe(string filepath)
		{
			int buf, pass;
			byte[] buffer = File.ReadAllBytes(filepath);
			byte[] decryptedtext = new byte[buf = buffer.Length];
			byte* password = stackalloc byte[pass = encryptionKey.Length];

			if (pass == 0) return Encoding.Default.GetString(buffer);

			for (int i = 0; i < pass; i++)
				password[i] = (byte)encryptionKey[i];

			fixed (byte* b = buffer, d = decryptedtext)
			{
				for (int i = 123, j = 0; i < buf; i++, j++)
					d[j] = (byte)(b[i] - password[j % pass]);
			}

			return Encoding.Default.GetString(decryptedtext);
		}

		public static void Encrypt(string text, string filepath)
		{
			if (!string.IsNullOrEmpty(Settings.Default.dataUtil) && UtilManager.Utils != null)
			{
				UtilManager.ActiveUtil.Encrypt(filepath, text);
				return;
			}

			byte[] dat = new byte[123 + text.Length];
			string password = decryptionKey;

			for (int i = 0; i < 123; i++)
				dat[i] = 0;
			if (string.IsNullOrEmpty(password))
				for (int i = 0, j = 123; i < text.Length; i++, j++)
					dat[j] = (byte)text[i];
			else
				for (int i = 0, j = 123; i < text.Length; i++, j++)
					dat[j] = (byte)((byte)text[i] + (byte)password[i % password.Length]);

			File.WriteAllBytes(filepath, dat);
		}

		public static unsafe void EncryptUnsafe(string text, string filepath)
		{
			int len, pass, txt;
			byte[] dat = new byte[len = 123 + (txt = text.Length)];
			byte* password = stackalloc byte[pass = decryptionKey.Length];

			for (int i = 0; i < pass; i++)
				password[i] = (byte)decryptionKey[i];

			fixed (byte* d = dat)
			{
				for (int i = 0; i < 123; i++)
					d[i] = 0;

				fixed (char* t = text)
				{
					if (pass == 0)
						for (int i = 0; i < txt; i++)
							d[i + 123] = (byte)t[i];
					else
						for (int i = 0, j = 123; i < txt; i++, j++)
							d[j] = (byte)((byte)t[i] + password[i % pass]);
				}
			}

			File.WriteAllBytes(filepath, dat);
		}
	}
}