namespace ClashRoyale.Network
{
    using System;
    using System.Threading;

    using ClashRoyale.Messages;

    using SuperSocket.SocketBase;

    public class SupercellDeviceSession : AppSession<SupercellDeviceSession, SupercellRequestInfo>
    {
        public int MessageReceived;
        public int MessageSent;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupercellDeviceSession"/> class.
        /// </summary>
        public SupercellDeviceSession()
        {
            // SupercellDeviceSession.
        }

        /// <summary>
        /// Handles the specified <see cref="Exception"/>.
        /// </summary>
        /// <param name="Exception">The exception.</param>
        protected override void HandleException(Exception Exception)
        {
            base.HandleException(Exception);

            if (string.IsNullOrEmpty(Exception.Message) == false)
            {
                Logging.Error(this.GetType(), Exception.GetType().Name + ", " + Exception.Message);
            }
        }

        /// <summary>
        /// Handles the unknown request.
        /// </summary>
        /// <param name="Request">The request info.</param>
        protected override void HandleUnknownRequest(SupercellRequestInfo Request)
        {
            base.HandleUnknownRequest(Request);

            if (Request.IsValid())
            {
                Logging.Info(this.GetType(), "Valid unhandled unknown request!");
            }
            else
            {
                Logging.Info(this.GetType(), "Invalid unhandled unknown request!");
            }
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        public void SendMessage(Message Message)
        {
            byte[] Buffer = Message.ToBytes();

            if (this.TrySend(Buffer, 0, Buffer.Length) == false)
            {
                Logging.Info(this.GetType(), "this.TrySend(Buffer, 0, Buffer.Length) != true at SendMessage(Message).");
            }

            Interlocked.Increment(ref this.MessageSent);
        }
    }
}
