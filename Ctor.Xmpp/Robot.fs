namespace Ctor.Xmpp

open System
open System.Threading

open Microsoft.Extensions.Logging
open SharpXMPP
open SharpXMPP.XMPP

type Robot(loggerFactory: ILoggerFactory,
           login: string,
           password: string,
           roomJid: string,
           nickname: string) =
    let logger = loggerFactory.CreateLogger<Robot>()
    let connection = new XmppClient(JID(login), password)

    let connectionFailedHandler = XmppConnection.ConnectionFailedHandler(fun s e ->
        logger.LogError(e.ToString())
        Thread.Sleep(TimeSpan.FromSeconds(30.0)) // TODO[Friedrich]: Configurable timeout.
        ())

    let signedInHandler = XmppConnection.SignedInHandler(fun s e ->
        logger.LogInformation("Connecting to " + roomJid)
        SharpXmppHelper.joinRoom connection roomJid nickname)

    let messageHandler = XmppConnection.MessageHandler(fun s e ->
        logger.LogInformation("<-" + e.ToString()))

    let elementHandler = XmppConnection.ElementHandler(fun s e ->
        let arrow = if e.IsInput then "<-" else "->"
        logger.LogInformation(arrow + " " + e.ToString()))

    do
        connection.add_ConnectionFailed(connectionFailedHandler)
        connection.add_SignedIn(signedInHandler)
        connection.add_Message(messageHandler)
        connection.add_Element(elementHandler)

    interface IDisposable with
        member __.Dispose() = connection.Close()
