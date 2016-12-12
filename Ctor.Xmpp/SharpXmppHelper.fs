module Ctor.Xmpp.SharpXmppHelper

open System.Xml.Linq

open SharpXMPP
open SharpXMPP.XMPP.Client.MUC.Bookmarks.Elements

let private bookmark (roomJid: string) (nickname: string): BookmarkedConference =
    let room = BookmarkedConference()
    room.SetAttributeValue(XName.Get("jid"), roomJid)
    let nickElement = XElement(XName.Get("storage:bookmarks"), "nick", Value = nickname)
    room.Add(nickElement)
    room

let joinRoom (client: XmppClient) (roomJid: string) (nickname: string): unit =
    let room = bookmark roomJid nickname
    client.BookmarkManager.Join(room)
