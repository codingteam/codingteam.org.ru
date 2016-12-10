codingteam.org.ru [![Build status][badge-travis]][status-travis]
=================

This is the code that services [codingteam.org.ru][] web
site.

### Prerequisites

To install and run the site, you need to install crossplatform [.NET
Core][dotnet] tool and [Node.js package manager][node-js].

### Configuration

The only configuration parameter is the HTTP binding. Change the binding using
`ASPNETCORE_URLS` environment variable. For example,
`ASPNETCORE_URLS=http://0.0.0.0:80` means listening port 80 for all addresses.
The default setting is `http://localhost:5000`.

You may specify some of the application settings in the `appsettings.json` file.
The main settings section is `CtorSettings`:

```js
"CtorSettings": {
    "LogUrlPrefix": "http://<url to log service without last backslash>",
    "LogTimeZoneOffset": 0 // time zone offset on the log server (in hours)
},
```

### Building

Prepare for the build (set the dependencies up):

```console
$ npm install
$ dotnet restore
```

Build the project:

```console
$ npm run build
$ dotnet build Ctor.Server
```

Execute the local build:

```console
$ cd Ctor.Server
$ dotnet run
```

Prepare the production-ready package:

```console
$ dotnet publish Ctor.Server -c release
```

### Deployment

The site can be deployed to any platform capable of running [dotnet][]. See
[deployment documentation][deployment] for information about current production
environment.

[codingteam.org.ru]: https://codingteam.org.ru/
[deployment]: docs/deployment.md
[dotnet]: https://dot.net/
[node-js]: https://nodejs.org/en/
[status-travis]: https://travis-ci.org/codingteam/codingteam.org.ru

[badge-travis]: https://travis-ci.org/codingteam/codingteam.org.ru.png?branch=develop
