namespace ClashRoyale.Handlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ClashRoyale.Logic;
    using ClashRoyale.Messages;

    internal static class HandlerFactory
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MessageHandlers"/> has been initialized.
        /// </summary>
        internal static bool Initialized
        {
            get;
            set;
        }

        /// <summary>
        /// The message handler, used to process the received and sent messages.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Message">The message.</param>
        /// <param name="Cancellation">The cancellation token.</param>
        public delegate Task MessageHandler(Device Device, Message Message, CancellationToken Cancellation);

        /// <summary>
        /// The dictionnary of handlers, used to route packet ids and handle them.
        /// </summary>
        public static readonly Dictionary<short, MessageHandler> MessageHandlers = new Dictionary<short, MessageHandler>();

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        internal static void Initialize()
        {
            if (HandlerFactory.Initialized)
            {
                return;
            }

            /* HandlerFactory.MessageHandlers.Add(new ClientHelloMessage().Identifier,                   ClientHelloHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new ServerHelloMessage().Identifier,                   ServerHelloHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new LoginMessage().Identifier,                         LoginHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new LoginOkMessage().Identifier,                       LoginOkHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new LoginFailedMessage().Identifier,                   LoginFailedHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new ClientCapabilitiesMessage().Identifier,            ClientCapabilitiesHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new EndClientTurnMessage().Identifier,                 EndClientTurnHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new ChangeAvatarNameMessage().Identifier,              ChangeAvatarNameHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new KeepAliveMessage().Identifier,                     KeepAliveHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new KeepAliveOkMessage().Identifier,                   KeepAliveOkHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new AskForAvatarStreamMessage().Identifier,            AskForAvatarStreamHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new AskForBattleReplayStreamMessage().Identifier,      AskForBattleReplayStreamHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new OwnHomeDataMessage().Identifier,                   OwnHomeDataHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new GoHomeMessage().Identifier,                        GoHomeHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new VisitHomeMessage().Identifier,                     VisitHomeHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new HomeBattleReplayMessage().Identifier,              HomeBattleReplayHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new AskForAllianceDataMessage().Identifier,            AskForAllianceDataHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new CancelMatchmakeMessage().Identifier,               CancelMatchmakeHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new StartTrainingBattleMessage().Identifier,           StartTrainingBattleHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new SectorCommandMessage().Identifier,                 SectorCommandHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new SendBattleEventMessage().Identifier,               SendBattleEventHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new AskForTvContentMessage().Identifier,               AskForTvContentHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new ServerErrorMessage().Identifier,                   ServerErrorHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new ServerShutdownMessage().Identifier,                ServerShutdownHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new DisconnectedMessage().Identifier,                  DisconnectedHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new AskForAvatarRankingListMessage().Identifier,       AskForAvatarRankingListHandler.Handle);
            HandlerFactory.MessageHandlers.Add(new AskForAvatarLocalRankingListMessage().Identifier,  AskForAvatarLocalRankingListHandler.Handle);

            HandlerFactory.MessageHandlers.Add(new CreateAllianceMessage().Identifier,                CreateAllianceHandler.Handle); */

            HandlerFactory.Initialized = true;
        }

        /// <summary>
        /// Handles the specified <see cref="Message"/> using the specified <see cref="Device"/>.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Message">The message.</param>
        /* public static async Task<bool> MessageHandle(Device Device, Message Message)
        {
            using (var Cancellation = new CancellationTokenSource())
            {
                var Token = Cancellation.Token;

                if (HandlerFactory.MessageHandlers.TryGetValue(Message.Identifier, out MessageHandler Handler))
                {
                    Cancellation.CancelAfter(4000);

                    try
                    {
                        await Handler(Device, Message, Token);
                    }
                    catch (LogicException)
                    {
                        // Handled.
                    }
                    catch (OperationCanceledException)
                    {
                        Logging.Warning(typeof(MessageHandler), "Operation has been cancelled after 4 seconds, while processing " + Message.GetType().Name + ".");
                    }
                    catch (Exception Exception)
                    {
                        Logging.Error(typeof(MessageHandler), "Operation has been aborted because of a " + Exception.GetType().Name + ", while processing " + Message.GetType().Name + ".");
                    }

                    if (Cancellation.IsCancellationRequested == false)
                    {
                        if (Device.GameMode != null)
                        {
                            if (Device.GameMode.Player != null)
                            {
                                await Players.Save(Device.GameMode.Player);
                            }
                        }

                        return true;
                    }
                    else
                    {
                        Logging.Warning(typeof(MessageHandler), "Operation has been cancelled after processing " + Message.GetType().Name + ".");
                    }
                }
            }

            return false;
        } */
    }
}