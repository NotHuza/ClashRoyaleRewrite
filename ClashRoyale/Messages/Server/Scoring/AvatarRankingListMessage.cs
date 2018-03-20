namespace ClashRoyale.Messages.Server.Scoring
{
    using ClashRoyale.Enums;
    using ClashRoyale.Extensions;
    using ClashRoyale.Logic.Scoring;

    public class AvatarRankingListMessage : Message
    {
        /// <summary>
        /// Gets the identifier of this message.
        /// </summary>
        public override short Identifier
        {
            get
            {
                return 29733;
            }
        }

        /// <summary>
        /// Gets the service node of this message.
        /// </summary>
        public override Node ServiceNode
        {
            get
            {
                return Node.Scoring;
            }
        }
        
        public AvatarRankingEntry[] Entries;
        public AvatarRankingEntry[] LastSeasonEntries;

        public int TimeLeft;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarRankingListMessage"/> class.
        /// </summary>
        public AvatarRankingListMessage()
        {
            // AvatarRankingListMessage.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarRankingListMessage"/> class.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public AvatarRankingListMessage(ByteStream Stream) : base(Stream)
        {
            // AvatarRankingListMessage.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarRankingListMessage"/> class.
        /// </summary>
        /// <param name="Entries">The entries.</param>
        /// <param name="LastSeasonEntries">The last season entries.</param>
        public AvatarRankingListMessage(AvatarRankingEntry[] Entries, AvatarRankingEntry[] LastSeasonEntries)
        {
            this.Entries = Entries;
            this.LastSeasonEntries = LastSeasonEntries;
        }

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public override void Decode()
        {
            this.Entries = new AvatarRankingEntry[this.Stream.ReadVInt()];

            for (int i = 0; i < this.Entries.Length; i++)
            {
                AvatarRankingEntry Entry = new AvatarRankingEntry();
                Entry.Decode(this.Stream);
                this.Entries[i] = Entry;
            }

            this.LastSeasonEntries = new AvatarRankingEntry[this.Stream.ReadVInt()];

            for (int i = 0; i < this.LastSeasonEntries.Length; i++)
            {
                AvatarRankingEntry Entry = new AvatarRankingEntry();
                Entry.Decode(this.Stream);
                this.LastSeasonEntries[i] = Entry;
            }

            this.TimeLeft = this.Stream.ReadInt();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public override void Encode()
        {
            this.Stream.WriteVInt(this.Entries.Length);

            foreach (AvatarRankingEntry Entry in this.Entries)
            {
                Entry.Encode(this.Stream);
            }

            this.Stream.WriteInt(this.LastSeasonEntries.Length);

            foreach (AvatarRankingEntry Entry in this.LastSeasonEntries)
            {
                Entry.Encode(this.Stream);
            }

            this.Stream.WriteInt(this.TimeLeft);
        }
    }
}