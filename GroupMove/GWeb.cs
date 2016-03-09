using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GroupMove
{
	public class GWeb
	{
		/// <summary>
		/// Downloads a file and saves it to disk.
		/// </summary>
		/// <param name="fullHrefToFile">A full path to the file to be downloaded from the internet.</param>
		/// <param name="fullFileDestinationName">
		///		Path and name of the file to save.
		///		If a file at this location name previously exists it will be overwritten.
		///		Be careful because if you do not provide a path including the filename 
		///		The file will be saved into the current filesystem folder.
		/// </param>
		/// <returns>true  if the file was downloaded successfully otherwize false</returns>
		public bool DownloadFile(string fullHrefToFile, string fullFileDestinationName)
		{
			string remoteUri = fullHrefToFile;
			bool success = false;

			// Create a new WebClient instance.
			using (WebClient myWebClient = new WebClient())
			{
				try
				{
					myWebClient.DownloadFile(fullHrefToFile, fullFileDestinationName);
					success = true;
				}
				catch (Exception e)
				{
					//EAT THIS
				}
				
			}
			return success;
		}
	}
}
