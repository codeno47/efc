using System;
using System.Collections.Generic;

namespace Experion.FileManager.Services.Dto
{
    [Serializable]
    public class MailInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailInfo"/> class.
        /// </summary>
        public MailInfo()
        {
            ToAddress = new List<string>();
            CcAddress = new List<string>();
            BccAddress = new List<string>();
        }

        /// <summary>
        /// Gets or sets the mail server.
        /// </summary>
        /// <value>
        /// The mail server.
        /// </value>
        public string MailServer { get; set; }

        /// <summary>
        /// Gets or sets from email.
        /// </summary>
        /// <value>
        /// From email.
        /// </value>
        public string FromEmail { get; set; }

        /// <summary>
        /// Gets or sets the automatic address.
        /// </summary>
        /// <value>
        /// The automatic address.
        /// </value>
        public List<string> ToAddress { get; set; }

        /// <summary>
        /// Gets or sets the cc address.
        /// </summary>
        /// <value>
        /// The cc address.
        /// </value>
        public List<string> CcAddress { get; set; }

        /// <summary>
        /// Gets or sets the BCC address.
        /// </summary>
        /// <value>
        /// The BCC address.
        /// </value>
        public List<string> BccAddress { get; set; } 
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is SSL enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is SSL enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSslEnabled { get; set; }

        /// <summary>
        /// Gets or sets the attachment file.
        /// </summary>
        /// <value>
        /// The attachment file.
        /// </value>
        public string AttachmentFile { get; set; }
    }
}
