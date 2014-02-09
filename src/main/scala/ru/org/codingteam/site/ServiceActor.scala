package ru.org.codingteam.site

import akka.actor.Actor
import spray.routing._
import org.joda.time.{DateTimeZone, DateTime}
import spray.http.StatusCodes

// we don't implement our route structure directly in the service actor because
// we want to be able to test it independently, without having to spin up an actor
class ServiceActor extends Actor with Service {

  // the HttpService trait defines only one abstract member, which
  // connects the services environment to the enclosing actor or test
  def actorRefFactory = context

  // this actor only runs our route, but you could add
  // other things here, like request stream processing
  // or timeout handling
  def receive = runRoute(myRoute)
}

// this trait defines our service behavior independently from the service actor
trait Service extends HttpService {

  val myRoute =
    path("") {
      dynamic {
        val timeZoneOffset = 4
        val date = DateTime.now(DateTimeZone.forOffsetHours(timeZoneOffset))

        val year = date.getYear
        val month = "%02d" format date.getMonthOfYear
        val day = "%02d" format date.getDayOfMonth

        redirect(
          s"http://0xd34df00d.me/logs/chat/codingteam@conference.jabber.ru/$year/$month/$day.html",
          StatusCodes.Found)
      }
    } ~
    path("version") {
      get {
        val version = Option(classOf[Service].getPackage.getImplementationVersion).getOrElse("development")
        complete {
          s"$version"
        }
      }
    }
}