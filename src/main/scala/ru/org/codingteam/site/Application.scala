package ru.org.codingteam.site

import akka.actor.{ActorSystem, Props}
import akka.io.IO
import spray.can.Http
import akka.pattern.ask
import akka.util.Timeout
import scala.concurrent.duration._

object Application extends App {

  implicit val system = ActorSystem("codingteam-org-ru-site")

  val service = system.actorOf(Props[ServiceActor], "site-service")

  implicit val timeout = Timeout(5.seconds)

  IO(Http) ? Http.Bind(service, interface = "localhost", port = 8080)
}
