using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GroupMove
{
	class FileCollect
	{
		private string _rootDir;
		private string _searchString;
		private List<string> _filesPaths; 
		public FileCollect(string rootDir, string searchString)
		{
			_rootDir = rootDir;
			_searchString = searchString;

		_filesPaths = new List<string>();
			PopulateFileNames();
		}

		public FileCollect(string rootDir)
		{
			_rootDir = rootDir;
			_searchString = "*.*";
			_filesPaths = new List<string>();
		}
		public void Add(string fullFileName)
		{
			_filesPaths.Add(fullFileName);
		}
		public void Remove(string fullFileName)
		{
			_filesPaths.Remove(fullFileName);
		}
		/// <summary>
		/// Searches for filenames and if found adds a full filename, 
		/// including the paht to the list
		/// </summary>
		private void PopulateFileNames()
		{
			string[] dirEntries = Directory.GetDirectories(_rootDir);
			foreach (string dirPath in dirEntries)
			{
				string[] fileEntries = Directory.GetFiles(dirPath, _searchString);
				foreach (string fileName in fileEntries)
				{
					_filesPaths.Add(fileName);
				}
				
			}
		}

		public int Count()
		{
			return _filesPaths.Count();
		}


		/// <summary>
		/// Gets a array of filnames.
		/// </summary>
		/// <returns>An array containing only the filename.</returns>
		public string[] GetFileNames()
		{
			if (_filesPaths.Count < 1)
				return null;
			List<string> list = _filesPaths.Select(Path.GetFileName).ToList();

			return list.ToArray();
		}


		/// <summary>
		/// Gets a array of full filnames.
		/// </summary>
		/// <returns>An array containing path and filename.</returns>
		public string[] GetFullFileNames()
		{
			return _filesPaths.Count < 1 ? null : _filesPaths.ToArray();
		}
	}
}
