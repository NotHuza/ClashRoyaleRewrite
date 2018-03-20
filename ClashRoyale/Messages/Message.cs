namespace ClashRoyale.Messages
{
    using System;

    using ClashRoyale.Enums;
    using ClashRoyale.Extensions;

    public class Message : IDisposable
    {
        /// <summary>
        /// The service node of this <see cref="Message"/>.
        /// </summary>
        public virtual Node ServiceNode
        {
            get
            {
                throw new Exception(this.GetType() + ", service node type must be overridden.");
            }
        }
        
        /// <summary>
        /// The identifier of this <see cref="Message"/>.
        /// </summary>
        public virtual short Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the length of this <see cref="Message"/>
        /// </summary>
        public int Length
        {
            get
            {
                return this.Stream.Length;
            }
        }
        
        /// <summary>
        /// Gets the version of this <see cref="Message"/>.
        /// </summary>
        public short Version
        {
            get;
            set;
        }

        /// <summary>
        /// The message stream, used to.. read or write the message.
        /// </summary>
        public ByteStream Stream
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        public Message()
        {
            this.Stream = new ByteStream();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public Message(ByteStream Stream) : this()
        {
            this.Stream = Stream;
        }

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public virtual void Decode()
        {
            // Decode.
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public virtual void Encode()
        {
            // Encode.
        }

        /// <summary>
        /// Turns this <see cref="Message"/> into a byte array.
        /// </summary>
        public byte[] ToBytes()
        {
            using (ByteStream Stream = new ByteStream(this.Length + 7))
            {
                Stream.WriteShort(this.Identifier);
                Stream.WriteInt24(this.Length);
                Stream.WriteShort(this.Version);

                Stream.AddRange(Stream.ToArray());
            }

            return this.Stream.ToArray();
        }

        /// <summary>
        /// Exécute les tâches définies par l'application associées
        /// à la libération ou à la redéfinition des ressources non managées.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="Disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                this.Stream.Dispose();
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Message"/> class.
        /// </summary>
        ~Message()
        {
            this.Dispose(false);
        }
    }
}