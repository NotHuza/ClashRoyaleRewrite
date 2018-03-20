namespace ClashRoyale.Network
{
    using System;

    using SuperSocket.SocketBase.Protocol;

    public class SupercellRequestInfo : IRequestInfo
    {
        /// <summary>
        /// Gets the key of this request.
        /// </summary>
        public string Key
        {
            get;
        }

        /// <summary>
        /// Gets the raw packet.
        /// </summary>
        public byte[] Raw
        {
            get;
        }

        /// <summary>
        /// Gets the header.
        /// </summary>
        public byte[] Header
        {
            get;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        public byte[] Body
        {
            get;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Identifier
        {
            get;
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        public int Length
        {
            get;
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public int Version
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SupercellRequestInfo"/> class.
        /// </summary>
        /// <param name="Identifier">The identifier.</param>
        /// <param name="Length">The length.</param>
        /// <param name="Version">The version.</param>
        /// <param name="Header">The header.</param>
        /// <param name="Body">The body.</param>
        public SupercellRequestInfo(int Identifier, int Length, int Version, byte[] Header, byte[] Body)
        {
            this.Identifier = Identifier;
            this.Length     = Length;
            this.Version    = Version;
            this.Header     = Header;
            this.Body       = Body;

            this.Raw        = new byte[Header.Length + Body.Length];

            Array.Copy(Header, 0, this.Raw, 0, Header.Length);
            Array.Copy(Body, 0, this.Raw, 7, Body.Length);
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid()
        {
            bool Valid = true;

            if (this.Identifier < 10000 || this.Identifier > 29999)
            {
                Valid = false;
            }
             
            if (this.Body.Length != this.Length)
            {
                Valid = false;
            }

            return Valid;
        }
    }
}
