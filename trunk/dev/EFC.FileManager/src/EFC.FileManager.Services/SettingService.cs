using System;
using System.IO;
using System.Xml.Serialization;
using EFC.FileManager.Services.Configuration;

namespace EFC.FileManager.Services
{
    public class SettingService
    {
        /// <summary>
        /// Loads the settings.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public FileManagerSection LoadSettings(string fileName)
        {
            return Deserialize<FileManagerSection>(fileName);
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void SaveSettings(FileManagerSection settings, string fileName)
        {
            Serialize(settings, fileName);
        }

        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static bool Serialize<T>(T value, String filename)
        {
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(filename, FileMode.Create);
                xmlserializer.Serialize(stream, value);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Deserializes the specified filename.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static T Deserialize<T>(String filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return default(T);
            }
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                var result = (T)xmlSerializer.Deserialize(stream);
                stream.Close();
                return result;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
