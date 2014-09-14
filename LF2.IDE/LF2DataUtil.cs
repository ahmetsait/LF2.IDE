using System;
using System.Text;
using System.IO;

namespace LF2.IDE
{
	public static class LF2DataUtil
	{
		public static string EncryptionKey { get { return Settings.Current.encryptionKey; } }
		public static string DecryptionKey { get { return Settings.Current.decryptionKey; } }

		public static string Decrypt(string filepath)
		{
			if (!string.IsNullOrEmpty(Settings.Current.dataUtil))
			{
				while (UtilManager.UtilLock) ;
				return UtilManager.ActiveUtil.Decrypt(filepath);
			}

			byte[] buffer = File.ReadAllBytes(filepath);
			byte[] decryptedtext = new byte[Math.Max(0, buffer.Length - 123)];
			string password = EncryptionKey;

			if (string.IsNullOrEmpty(password)) return Encoding.Default.GetString(buffer);

			for (int i = 0, j = 123; i < decryptedtext.Length; i++, j++)
				decryptedtext[i] = (byte)(buffer[j] - (byte)password[i % password.Length]);

			return Encoding.Default.GetString(decryptedtext);
		}

		public static unsafe string DecryptUnsafe(string filepath)
		{
			int dec, pass;
			byte[] buffer = File.ReadAllBytes(filepath);
			byte[] decryptedtext = new byte[dec = Math.Max(0, buffer.Length - 123)];
			byte* password = stackalloc byte[pass = EncryptionKey.Length];

			if (pass == 0) return Encoding.Default.GetString(buffer);

			for (int i = 0; i < pass; i++)
				password[i] = (byte)EncryptionKey[i];

			fixed (byte* b = buffer, d = decryptedtext)
			{
				for (int i = 0, j = 123; i < dec; i++, j++)
					d[i] = (byte)(b[j] - password[i % pass]);
			}

			return Encoding.Default.GetString(decryptedtext);
		}

		public static void Encrypt(string text, string filepath)
		{
			if (!string.IsNullOrEmpty(Settings.Current.dataUtil))
			{
				while (UtilManager.UtilLock) ;
				UtilManager.ActiveUtil.Encrypt(filepath, text);
				return;
			}

			byte[] dat = new byte[123 + text.Length];
			string password = DecryptionKey;

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
			byte* password = stackalloc byte[pass = DecryptionKey.Length];

			for (int i = 0; i < pass; i++)
				password[i] = (byte)DecryptionKey[i];

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