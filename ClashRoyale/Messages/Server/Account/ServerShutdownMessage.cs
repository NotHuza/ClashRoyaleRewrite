namespace ClashRoyale.Messages.Server.Account
{
    using ClashRoyale.Enums;
    using ClashRoyale.Extensions;

    public class ServerShutdownMessage : Message
    {
        /// <summary>
        /// Gets the identifier of this message.
        /// </summary>
        public override short Identifier
        {
            get
            {
                return 20161;
            }
        }

        /// <summary>
        /// Gets the service node of this message.
        /// </summary>
        public override Node ServiceNode
        {
            get
            {
                return Node.Account;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerShutdownMessage"/> class.
        /// </summary>
        public ServerShutdownMessage()
        {
            // ServerShutdownMessage.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerShutdownMessage"/> class.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public ServerShutdownMessage(ByteStream Stream) : base(Stream)
        {
            // ServerShutdownMessage.
        }
    }
}