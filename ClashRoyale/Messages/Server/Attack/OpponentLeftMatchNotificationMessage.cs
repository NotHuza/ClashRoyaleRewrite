namespace ClashRoyale.Messages.Server.Attack
{
    using ClashRoyale.Enums;
    using ClashRoyale.Extensions;

    public class OpponentLeftMatchNotificationMessage : Message
    {
        /// <summary>
        /// Gets the identifier of this message.
        /// </summary>
        public override short Identifier
        {
            get
            {
                return 20801;
            }
        }

        /// <summary>
        /// Gets the service node of this message.
        /// </summary>
        public override Node ServiceNode
        {
            get
            {
                return Node.Attack;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpponentLeftMatchNotificationMessage"/> class.
        /// </summary>
        public OpponentLeftMatchNotificationMessage()
        {
            // OpponentLeftMatchNotificationMessage.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpponentLeftMatchNotificationMessage"/> class.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public OpponentLeftMatchNotificationMessage(ByteStream Stream) : base(Stream)
        {
            // OpponentLeftMatchNotificationMessage.
        }
    }
}