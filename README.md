codingteam.org.ru [![Docker Image][badge.docker]][docker-hub]
=================

This is the code that services [codingteam.org.ru][] website.

Prerequisites
-------------

To build the application, you'll need to install [.NET Core SDK][dotnet] 3.1.201+.

To run the application, [.NET Core Runtime][dotnet] 3.1 is required.

Configure
---------

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

Build
-----

Prepare for the build (set the dependencies up):

```console
$ npm ci
```

Build the project:

```console
$ npm run build
$ dotnet build
```

Run
---

```console
$ dotnet run --project Codingteam.Site
```

Test
----

To run the project tests, execute the following command:

```console
$ dotnet test --configuration Release
```

Publish
-------

Prepare the production-ready distribution in the `publish` directory:

```console
$ dotnet publish --configuration Release --output publish Codingteam.Site
```

This application uses Docker for deployment. To create a Docker image, use the
following command:

```console
$ docker build -t codingteam/codingteam.org.ru:$CODINGTEAM_ORG_RU_VERSION -t codingteam/codingteam.org.ru:latest .
```

(where `$CODINGTEAM_ORG_RU_VERSION` is the version for the image to use)

Then push the image to the Docker Hub:

```console
$ docker login # if necessary
$ docker push codingteam/codingteam.org.ru:$CODINGTEAM_ORG_RU_VERSION
$ docker push codingteam/codingteam.org.ru:latest
```

Deploy
------

To install the application from Docker, run the following command:

```console
$ docker run -d --restart unless-stopped -p:$PORT:80 --name $NAME -v $CONFIG:/app/appsettings.json codingteam/codingteam.org.ru:$VERSION
```

Where
- `$PORT` is the port you want to expose the application on
- `$NAME` is the container name
- `$CONFIG` is the **absolute** path to the configuration file override (if
  necessary)
- `$VERSION` is the version you want to deploy, or `latest` for the latest
  available one

For example, a production server may use the following settings (note this
command uses the Bash syntax; adapt for your shell if necessary):

```bash
PORT=5000
NAME=codingteam.org.ru
VERSION=latest
docker pull codingteam/codingteam.org.ru:$VERSION
docker rm -f $NAME
docker run -d --restart unless-stopped -p $PORT:80 --name $NAME codingteam/codingteam.org.ru:$VERSION
```

Documentation
-------------

- [Changelog][changelog]
- [License][license]

[badge.docker]: https://img.shields.io/docker/v/codingteam/codingteam.org.ru?sort=semver

[changelog]: CHANGELOG.md
[codingteam.org.ru]: https://codingteam.org.ru/
[docker-hub]: https://hub.docker.com/r/codingteam/codingteam.org.ru
[dotnet]: https://dot.net/
[license]: LICENSE.md
