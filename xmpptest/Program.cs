using System;
using System.Xml.Linq;
using SharpXMPP;
using SharpXMPP.XMPP;
using SharpXMPP.XMPP.Client.MUC.Bookmarks.Elements;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var c = new XmppClient(new JID("yyyyyy@jabber.ru"), "xxxxxxx");
            c.SignedIn += (_, __) => {
                Console.WriteLine("Connected");
                var room = new BookmarkedConference();
                room.SetAttributeValue("jid", "codingteam@conference.jabber.ru");

                var element = new XElement("storage:bookmarks", "nick");
                element.Value = "hortolet";
                room.Add(element);

                c.BookmarkManager.Join(room);
            };

            c.Message += (s, e) => {
                Console.Write("<-"); Console.WriteLine(e);
            };

            c.Element += (s, e) => {
                Console.Write(e.IsInput ? "<-" : "->"); Console.WriteLine(e.Stanza);
            };

            Console.WriteLine("Connecting...");
            c.Connect();



            Console.ReadLine();
        }
    }
}
