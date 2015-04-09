// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="HttpContextHandler.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="HttpContextHandler.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

namespace EFC.Components.Http
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// The class remote handler
    /// </summary>
    public class HttpContextHandler : IRemoteHandler
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// The handler
        /// </summary>
        private HttpClientHandler handler;

        /// <summary>
        /// Gets or sets the HTTP client.
        /// </summary>
        /// <value>
        /// The HTTP client.
        /// </value>
        private HttpClient HttpClient
        {
            get
            {
                if (this.httpClient != null)
                {
                    return this.httpClient;
                }

                this.handler = new HttpClientHandler { UseDefaultCredentials = true };
                this.httpClient = new HttpClient(this.handler);

                return this.httpClient;
            }

            set
            {
                this.httpClient = value;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            this.httpClient.Dispose();

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }

            this.disposed = true;
        }

        /// <summary>
        /// Processes the post request.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns>
        /// response generic instance
        /// </returns>
        public async Task<TInstance> ProcessPostRequest<TInstance>(string url, dynamic data)
        {
            this.httpClient = new HttpClient();

            var microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var content = new StringContent(JsonConvert.SerializeObject(data, microsoftDateFormatSettings), Encoding.UTF8, "text/json");

            try
            {
                var response = await this.HttpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var serializeResponse = JsonConvert.DeserializeObject<TInstance>(responseBody);
                return serializeResponse;
            }
            catch (Exception exception)
            {
                var message =
                    string.Format(
                        "Error while connecting service:Http Post Request Failed URL:{0}, Params:{1}.",
                        url,
                        content);
                message += "\nError Message:" + exception.Message;
                throw new ClientHttpException(message, exception);
            }
        }

        /// <summary>
        /// Processes the get request.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// response generic instance
        /// </returns>
        public async Task<TInstance> ProcessGetRequest<TInstance>(string url)
        {
            try
            {
                var response = await this.HttpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var serializeResponse = JsonConvert.DeserializeObject<TInstance>(responseBody);

                return serializeResponse;
            }

            catch (Exception exception)
            {
                var message =
                    string.Format(
                        "Error while connecting service:Http GET Request Failed URL:{0}.",
                        url);
                message += "\nError Message:" + exception.Message;
                throw new ClientHttpException(message, exception);
            }
        }
    }
}
