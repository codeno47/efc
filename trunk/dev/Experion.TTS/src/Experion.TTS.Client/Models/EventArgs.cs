using System;

namespace Experion.TTS.Client.Models
{
    public class EventArgs<TInstance> : EventArgs
    {
        public object Sender { get; set; }

        public TInstance Data { get; set; }
    }
}
