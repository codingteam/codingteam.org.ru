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
Consider using the following [Ansible][ansible] task for deployment:
```yaml
- name: Set up the Docker container
  community.docker.docker_container:
    name: codingteam.org.ru
    image_name_mismatch: recreate
    image: codingteam/codingteam.org.ru:{{ codingteam_org_ru_version }}
    published_ports:
      - '5000:5000'
    restart_policy: unless-stopped
    default_host_ip: ''
    env:
      ASPNETCORE_URLS: "http://+:5000"
```

This will deploy the Docker container version `{{ codingteam_org_ru_version }}` and make it to listen port `5000` on the host.

Documentation
-------------

- [Changelog][changelog]
- [Maintainership][docs.maintainership]
- [License][license]

[ansible]: https://docs.ansible.com/
[badge.docker]: https://img.shields.io/docker/v/codingteam/codingteam.org.ru?sort=semver
[changelog]: CHANGELOG.md
[codingteam.org.ru]: https://codingteam.org.ru/
[docker-hub]: https://hub.docker.com/r/codingteam/codingteam.org.ru
[docs.maintainership]: MAINTAINERSHIP.md
[dotnet]: https://dot.net/
[license]: LICENSE.md
