cor-site
========
This is the code meant to service the http://codingteam.org.ru web site.

### Prerequisites
For site functioning you will need:

1. `java`
2. `sbt`

### Running
This project uses the `sbt` build system. So you should be able to execute

    $ sbt run

to run the project for testing. For deployment see the next section.

### Deployment
Currently our deployment procedure is tuned up for the Ubuntu 12.04 distributive.

Create a user for project:

    $ sudo useradd -m -s /bin/false cor-site

Make a directory where all will be stored:

    $ sudo mkdir -p /opt/codingteam/cor-site
    $ sudo chown cor-site /opt/codingteam/cor-site

Give an access for starting and stopping the `cor-site` daemon to user. Add this to the `sudoers` file:

    cor-site ALL = (root) NOPASSWD: /sbin/start cor-site, /sbin/stop cor-site

Clone git repository:

    $ cd /opt/codingteam/cor-site
    $ sudo -u cor-site git clone https://github.com/codingteam/cor-site.git .

Initialize the start script:

    $ sudo cp src/main/upstart/cor-site.conf /etc/init/

Tune up port configuration:

    $ sudo setcap cap_net_bind_service=+ep /usr/lib/jvm/java-6-openjdk-amd64/jre/bin/java

(Replace `/usr/lib/jvm/java-6-openjdk-amd64/jre/bin/java` with the path to the Java binary. You may also prefer some
other way of tuning the ports.)

Set up the `src/main/bash/check.sh` script for running as a `cron` job. Its working directory should be the git
repository. Execute

    $ sudo crontab -e -u cor-site

and add the file, for example,

    */5 * * * * cd /opt/codingteam/cor-site && bash ./src/main/bash/check.sh 2>&1 >> $HOME/check.log

Look for logs at `/var/log/upstart/cor-site.log`.

### Uninstallation
Delete the user:

    $ sudo userdel cor-site
    $ sudo rm -rf /home/cor-site

Stop the daemon:

    $ sudo stop cor-site

Cleanup the upstart config:

    $ sudo rm /etc/init/cor-site.conf

Cleanup the `sudoers` file (remove all lines granting anything to the `cor-site` user).

Remove the daemon directory:

    $ sudo rm -rf /opt/codingteam/cor-site
