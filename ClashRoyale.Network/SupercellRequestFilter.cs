namespace ClashRoyale.Network
{
    using System;

    using ClashRoyale.Exceptions;

    using SuperSocket.Facility.Protocol;

    public class SupercellRequestFilter : FixedHeaderReceiveFilter<SupercellRequestInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupercellRequestFilter"/> class.
        /// </summary>
        public SupercellRequestFilter() : base(7)
        {
            // SupercellRequestFilter.
        }

        /// <summary>
        /// Gets the body length from header.
        /// </summary>
        /// <param name="Header">The header.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Length">The length.</param>
        protected override int GetBodyLengthFromHeader(byte[] Header, int Offset, int Length)
        {
            if (Length < 7)
            {
                return 0;
            }

            byte[] Buffer = new byte[Length];
            Array.Copy(Header, Offset, Buffer, 0, Length);

            return Buffer[4] | Buffer[3] << 8 | Buffer[2] << 16;
        }

        /// <summary>
        /// Resolves the request information.
        /// </summary>
        /// <param name="Header">The header.</param>
        /// <param name="Body">The body.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Length">The length.</param>
        protected override SupercellRequestInfo ResolveRequestInfo(ArraySegment<byte> Header, byte[] Body, int Offset, int Length)
        {
            byte[] Buffer   = new byte[Length];

            Array.Copy(Body, Offset, Buffer, 0, Length);

            byte[] HeadArr  = Header.Array;

            short Type      = (short) (HeadArr[1] | HeadArr[0] << 8);
            short Version   = (short) (HeadArr[6] | HeadArr[5] << 8);

            var Request     = new SupercellRequestInfo(Type, Length, Version, HeadArr, Buffer);

            if (Request.IsValid() == false)
            {
                throw new LogicException(this.GetType(), "Request.IsValid() != true at ResolveRequestInfo(Header, Body, Offset, Length). ");
            }

            return Request;
        }
    }
}
