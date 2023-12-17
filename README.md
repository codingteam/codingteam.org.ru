codingteam.org.ru [![Docker Image][badge.docker]][docker-hub]
=================

This is the code that services [codingteam.org.ru][] website.

Prerequisites
-------------

To build the application, you'll need to install [.NET SDK][dotnet] 8.0+.

To run the application, [.NET Runtime][dotnet] 8.0 is required.

Configure
---------

The only configuration parameter is the HTTP binding. Change the binding using
`ASPNETCORE_URLS` environment variable. For example,
`ASPNETCORE_URLS=http://0.0.0.0:80` means listening port 80 for all addresses.
The default setting is `http://localhost:5000`.

Build
-----

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
$ docker run -d --restart unless-stopped -p:$PORT:80 --name $NAME codingteam/codingteam.org.ru:$VERSION
```

Where
- `$PORT` is the port you want to expose the application on
- `$NAME` is the container name
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
- [Maintainership][docs.maintainership]
- [License][license]

[badge.docker]: https://img.shields.io/docker/v/codingteam/codingteam.org.ru?sort=semver

[changelog]: CHANGELOG.md
[codingteam.org.ru]: https://codingteam.org.ru/
[docker-hub]: https://hub.docker.com/r/codingteam/codingteam.org.ru
[docs.maintainership]: MAINTAINERSHIP.md
[dotnet]: https://dot.net/
[license]: LICENSE.md
