cor-site
========
This is the code meant to service the http://codingteam.org.ru web site.

### Prerequisites
For site functioning you will need:
1. `java`
2. `sbt`

### Building
This project uses the `sbt` build system. So you should be able to run

```
$ sbt assembly
```

to build the project deployment-ready JAR package.

### Deployment
1. Create a user for project:

```
$ sudo useradd -r -s /bin/false cor-site
```

2. Make a directory where all will be stored:

```
$ sudo mkdir -p /opt/codingteam/cor-site
$ sudo chown cor-site /opt/codingteam/cor-site
```

3. Give an access for starting and stopping the `cor-site` daemon to user. Add this to the `sudoers` file:

```
cor-site ALL = (root) NOPASSWD: /sbin/start cor-site, /sbin/stop cor-site
```

4. Clone git repository:

```
$ cd /opt/codingteam/cor-site
$ sudo -u cor-site git clone https://github.com/codingteam/cor-site.git .
```

5. Initialize the start script:

```
$ sudo cp src/main/upstart/cor-site.conf /etc/init/
$ sudo chown cor-site /etc/init/cor-site.conf
```

5. Set up the `src/main/bash/check.sh` script for running as a `cron` job. Its working directory should be the git repository.
