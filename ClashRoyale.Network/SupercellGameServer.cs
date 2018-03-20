namespace ClashRoyale.Network
{
    using System;

    using SuperSocket.SocketBase;
    using SuperSocket.SocketBase.Protocol;

    public class SupercellGameServer : AppServer<SupercellDeviceSession, SupercellRequestInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupercellGameServer"/> class.
        /// </summary>
        public SupercellGameServer() : base(new DefaultReceiveFilterFactory<SupercellRequestFilter, SupercellRequestInfo>())
        {
            this.NewSessionConnected    += this.OnConnection;
            this.SessionClosed          += this.OnDisconnection;
            this.NewRequestReceived     += this.OnRequest;
        }

        /// <summary>
        /// Called when a new connection has been accepted.
        /// </summary>
        /// <param name="Session">The session.</param>
        private void OnConnection(SupercellDeviceSession Session)
        {
            // Console.WriteLine("[*] OnConnection().");
        }

        /// <summary>
        /// Called when a connection has been closed.
        /// </summary>
        /// <param name="Session">The session.</param>
        /// <para name="Reason">The reason.</para>
        private void OnDisconnection(SupercellDeviceSession Session, CloseReason Reason)
        {
            // Console.WriteLine("[*] OnDisconnection().");
        }

        /// <summary>
        /// Called when a session has made a request.
        /// </summary>
        /// <param name="Session">The session.</param>
        /// <param name="Request">The request.</param>
        private void OnRequest(SupercellDeviceSession Session, SupercellRequestInfo Request)
        {
            // Console.WriteLine("[*] OnRequest().");
            Console.WriteLine("[*] Message : ");
            Console.WriteLine("[*]  - Type    " + Request.Identifier);
            Console.WriteLine("[*]  - Length  " + Request.Length);
            Console.WriteLine("[*]  - Version " + Request.Version);
        }
    }
}
