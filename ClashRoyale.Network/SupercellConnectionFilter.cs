namespace ClashRoyale.Network
{
    using System.Net;

    using SuperSocket.SocketBase;

    public class SupercellConnectionFilter : IConnectionFilter
    {
        /// <summary>
        /// Gets the name of the filter.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes the <see cref="SupercellConnectionFilter"/>.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Server">The server.</param>
        public bool Initialize(string Name, IAppServer Server)
        {
            this.Name = Name;
            System.Console.WriteLine("Initialized " + Name);
            return true;
        }

        /// <summary>
        /// Returns a bool indicating whether we are
        /// allowing the connection or not.
        /// </summary>
        /// <param name="Address">The address.</param>
        public bool AllowConnect(IPEndPoint EndPoint)
        {
            string IpAddress = EndPoint.Address.ToString();

            if (IpAddress.StartsWith("88.189") || IpAddress.StartsWith("192.168"))
            {
                return true;
            }

            return false;
        }
    }
}
