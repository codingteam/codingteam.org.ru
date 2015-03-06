codingteam.org.ru
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

    $ cabal install --enable-tests

### Running
For development deployment run

    $ yesod devel [-p PORT]

After that visit http://localhost:PORT (3000 is default port for Yesod).

### Testing

    $ yesod test
