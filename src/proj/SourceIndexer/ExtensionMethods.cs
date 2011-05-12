namespace SourceIndexer
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Globalization;
	using System.IO;
	using System.Security.Cryptography;

	internal static class ExtensionMethods
	{
		public static string FormatWith(this string format, params object[] values)
		{
			return string.Format(CultureInfo.InvariantCulture, format, values);
		}

		public static string ExecuteCommand(this string executable, string arguments)
		{
			if (!File.Exists(executable))
				throw new FileNotFoundException("Executable file doesn't exist.");

			var command = new ProcessStartInfo(executable, arguments)
			{
				WorkingDirectory = Path.GetDirectoryName(executable) ?? string.Empty,
				UseShellExecute = false,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};

			using (var process = Process.Start(command))
			{
				var output = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
				return output;
			}
		}

		public static IEnumerable<string> Enumerate(this string value)
		{
			using (var reader = new StringReader(value ?? string.Empty))
			{
				string line;

				do
				{
					line = reader.ReadLine();
					if (!string.IsNullOrEmpty(line))
						yield return line;
				}
				while (line != null);
			}
		}

		public static string Standardize(this string path)
		{
			if (string.IsNullOrEmpty(path))
				return null;

			path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

			if (!Path.IsPathRooted(path) || path.Contains(".."))
				path = Path.GetFullPath(path);

			return path;
		}

		public static byte[] ComputeHash(this Stream inputStream)
		{
			using (HashAlgorithm algorithm = new SHA1Managed())
				return algorithm.ComputeHash(inputStream);
		}
		public static string FormatHash(this byte[] hash)
		{
			var hex = BitConverter.ToString(hash).ToLowerInvariant().Replace("-", "");
			return hex.Substring(0, 3) + "\\" + hex.Substring(3, 3) + "\\" + hex.Substring(6);
		}
	}
}