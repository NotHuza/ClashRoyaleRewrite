namespace ClashRoyale
{
    using System;

    using ClashRoyale.Database;
    using ClashRoyale.Handlers;

    using ClashRoyale.Network;

    internal static class Program
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Program"/> has been initialized.
        /// </summary>
        internal static bool Initialized
        {
            get;
            set;
        }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        internal static void Main()
        {
            Base.Initialize();
            GameDb.Initialize();

            HandlerFactory.Initialize();

            using (SupercellGameServer GameServer = new SupercellGameServer())
            {
                GameServer.Setup(9339);

                if (GameServer.Start() == false)
                {
                    Console.WriteLine("[*] Server failed to start.");
                }
            }
        }
    }
}