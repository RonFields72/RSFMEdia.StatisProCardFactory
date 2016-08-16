using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class FileHelper
    {
        /// <summary>
        /// Determines if a directory exists.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns></returns>
        public bool DirectoryExists(string directoryPath)
        {
            bool exists = false;
                        
            if (Directory.Exists(directoryPath))
            {
                exists = true;
            }
            
            return exists;
        }

        /// <summary>
        /// Creates the directory if it does not already exist.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        public void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Deletes the directory and everything in it.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        public void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}