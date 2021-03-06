﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Business
{
    /// <summary>
    /// FileHelper class is an abstraction over the System.IO functions in case you want to apply a user with more permissions.
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Determines if a directory exists.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns>true if directory exists, otherwise false.</returns>
        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath) ? true : false;
        }

        /// <summary>
        /// Determines if a file exists.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>true if file exists, otherwise false.</returns>
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath) ? true : false;
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

        /// <summary>
        /// Gets a collection of files in the specified path using the search filter
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <param name="directoryURL">The directory URL.</param>
        /// <param name="searchFilter">The search filter.</param>
        /// <returns></returns>
        public List<string> GetFileList(string directoryPath, string directoryURL, string searchFilter)
        {
            List<string> fileList = new List<string>();
            
                var files = Directory.EnumerateFiles(directoryPath, searchFilter);

                foreach (var currentFile in files)
                {
                    // TODO: process each file found
                    //UBHFile foundFile = new UBHFile();
                    var FileName = currentFile.Substring(directoryPath.Length);
                    //var FileURL = directoryURL + foundFile.FileName;
                    var FilePath = currentFile;
                    fileList.Add(string.Empty);
                }

            return fileList;
        }

        /// <summary>
        /// Copies a file from one location to another.
        /// </summary>
        /// <param name="originalFilePath">The original file path.</param>
        /// <param name="newFilePath">The new file path.</param>
        public void CopyFile(string originalFilePath, string newFilePath)
        {
            if (File.Exists(originalFilePath))
            {
                File.Copy(originalFilePath, newFilePath);
                DateTime newFileDate = DateTime.Now;
                File.SetCreationTime(newFilePath, newFileDate);
                File.SetLastWriteTime(newFilePath, newFileDate);
            }
        }
    }
}