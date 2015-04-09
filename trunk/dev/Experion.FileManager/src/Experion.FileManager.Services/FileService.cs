using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Experion.FileManager.Services
{
    public class IOFileService
    {
        /// <summary>
        /// Unloads the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void UnloadFile(string filename)
        {
            var info = new ProcessStartInfo {Arguments = "/s /d", FileName = @"Unlocker\Unlocker.exe"};
            Process.Start(info);
        }

        /// <summary>
        /// Deletes the files.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public void DeleteDirectoryFiles(string directory)
        {
            var fileGenerationDir = new DirectoryInfo(directory);
            var files = fileGenerationDir.GetFiles("*", SearchOption.AllDirectories).ToList();

            foreach (var file in files)
            {
                UnlockAndDelete(file.FullName);
            }
        }

        /// <summary>
        /// Unlocks the and delete.
        /// </summary>
        /// <param name="file">The file.</param>
        public void UnlockAndDelete(string file)
        {
            UnloadFile(file);
            DeleteFile(file);
        }

        public long CalculateFoldesize(string path)
        {
            var pathDirectory = Path.GetDirectoryName(path);
            // Get array of all file names.
            var a = Directory.GetFiles(pathDirectory, "*.*");

            // Calculate total bytes of all files in a loop.

            // Return total size
            return a.Select(name => new FileInfo(name)).Select(info => info.Length).Sum();
        }

        /// <summary>
        /// Deletes the directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public bool DeleteDirectory(string path)
        {
            try
            {
                var dir = new DirectoryInfo(path);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(true);
            }
            catch (Exception exception)
            {

                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets all directories.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <returns></returns>
        public List<string> GetAllDirectories(string rootPath)
        {
            return Directory.GetDirectories(rootPath).ToList();
        }

        /// <summary>
        /// Gets all files.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns></returns>
        public List<string> GetAllFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath).ToList();
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        public bool DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
