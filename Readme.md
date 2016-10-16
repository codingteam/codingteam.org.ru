codingteam.org.ru [![Build status][badge-travis]][status-travis]
=================

This is the code that services [codingteam.org.ru][] web
site.

### Prerequisites

To install and run the site, you need to install crossplatform [.NET
Core][dotnet] tool.

### Building

Prepare for the build (set the dependencies up):

```console
$ dotnet restore
```

Build the project:

```console
$ dotnet build
```

Execute the local build:

```console
$ dotnet run
```

Prepare the production-ready package:

```console
$ dotnet publish -c release
```

### Deployment

You may use this simple upstart configuration. The sample assumes the `cor-site`
user existence and that the application has been deployed to
`/opt/codingteam/codingteam.org.ru/`.

```
setuid cor-site
start on network
chdir /opt/codingteam/codingteam.org.ru/
exec dotnet /opt/codingteam/codingteam.org.ru/codingteam.org.ru.dll
```

Put this configuration to `/etc/init/cor-site.conf`.

[codingteam.org.ru]: http://codingteam.org.ru/
[dotnet]: https://dot.net/
[status-travis]: https://travis-ci.org/codingteam/codingteam.org.ru

[badge-travis]: https://travis-ci.org/codingteam/codingteam.org.ru.png?branch=develop
