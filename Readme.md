codingteam.org.ru
=================

This is the code that services [codingteam.org.ru][] website.

### Prerequisites

To build the application, you'll need to install [.NET Core SDK][dotnet]
3.1.201+ and [Node.js][node-js] 6.14+.

To run the application, [.NET Core Runtime][dotnet] 3.1 is required.

### Configuration

The only configuration parameter is the HTTP binding. Change the binding using
`ASPNETCORE_URLS` environment variable. For example,
`ASPNETCORE_URLS=http://0.0.0.0:80` means listening port 80 for all addresses.
The default setting is `http://localhost:5000`.

You may specify the application settings in the `appsettings.json` file. The
 main settings section is `CtorSettings`:

```js
"CtorSettings": {
    "LogUrlPrefix": "http://<url to log service without last backslash>",
    "LogTimeZoneOffset": 0 // time zone offset on the log server (in hours)
},
```

### Building

Prepare for the build (set the dependencies up):

```console
$ cd Codingteam.Site && npm ci
```

Build the project:

```console
$ cd Codingteam.Site && npm run build
$ cd .. && dotnet build
```

Execute the local build:

```console
$ dotnet run --project Codingteam.Site
```

Prepare the production-ready package:

```console
$ dotnet publish -c release
```

### Test

To run the project tests, execute the following command:

```console
$ dotnet test
```

### Deployment

The site can be deployed to any platform capable of running [dotnet][]. See
[deployment documentation][deployment] for information about current production
environment.

[codingteam.org.ru]: https://codingteam.org.ru/
[deployment]: docs/deployment.md
[dotnet]: https://dot.net/
[node-js]: https://nodejs.org/en/
