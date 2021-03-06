﻿// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="JsonHelper.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="JsonHelper.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Serializer
{
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// JSON Serialization and Deserialization Assistant Class
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// JSON Serialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public static string JsonSerializer<T>(T objectToSerialize)
        {
            return JsonSerializerInternal(objectToSerialize);
        }

        /// <summary>
        /// Jsons the serializec.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public static string JsonSerialize<T>(T objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        /// <summary>
        /// Jsons the serializer internal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize">The ObjectToSerialize.</param>
        /// <returns></returns>
        private static string JsonSerializerInternal<T>(T objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        /// <summary>
        /// Jsons the deserialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">The json string.</param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// Parses the json message.
        /// </summary>
        /// <param name="stringJson">The string json.</param>
        /// <returns></returns>
        public static Message ParseJsonMessage(string stringJson)
        {
            Message textResponse = null;
            if (WebOperationContext.Current != null)
            {
                {
                    textResponse = WebOperationContext.Current.CreateTextResponse(stringJson, "application/json; charset=utf-8", Encoding.Default);
                }
            }
            return textResponse;
        }
    }
}