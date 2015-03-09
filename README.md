codingteam.org.ru [![BuildStatus](https://travis-ci.org/codingteam/codingteam.org.ru.png?branch=develop)](https://travis-ci.org/codingteam/codingteam.org.ru)
=================
This is the code meant to service the [codingteam.org.ru](http://codingteam.org.ru) web site.

### Prerequisites
For site functioning you need [PostgreSQL](http://www.postgresql.org/) and working [Yesod](http://www.yesodweb.com/)
installation.

You should setup the database and a database user for site. Separate databases are used for testing and production
environments. The default database names are `"codingteam-site"` and `"codingteam-site_test"`.

### Configuration
Check [config/settings.yml](config/settings.yml). Test settings are stored in
[config/test-settings.yml](config/test-settings.yml).

### Building
Prepare for build (set up dependencies):

    $ cabal sandbox init
    $ cabal install --enable-tests

Real production-ready build:

    $ yesod build

### Running
For development deployment run

    $ yesod devel [-p PORT]

After that visit http://localhost:PORT (3000 is default port for Yesod).

### Testing

    $ yesod test

### Deployment

You may use simple upstart configuration (this example relies on `cor-site` user, and application was deployed to
`/opt/codingteam/codingteam.org.ru/`, and it uses http://codingteam.org.ru as the application root):

```
setuid cor-site
start on network
chdir /opt/codingteam/codingteam.org.ru/
env APPROOT=http://codingteam.org.ru
exec /opt/codingteam/codingteam.org.ru/codingteam-site
```

Put this configuration to `/etc/init/cor-site.conf` and upstart is configured.
