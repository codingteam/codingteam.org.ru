#!/bin/sh
oldVersion=`git rev-parse HEAD`
git pull origin master
newVersion=`git rev-parse HEAD`

if [ $oldVersion != $newVersion ]
then
    # Stop the daemon:
    sudo stop cor-site

    # Build new version:
    sbt clean
    sbt assembly

    # Replace the current code with the new version:
    rm -rf /opt/codingteam/cor-site
    mkdir /opt/codingteam/cor-site
    cp target/scala-2.10/*.jar /opt/codingteam/cor-site/

    # Replace the daemon script:
    cp scr/main/upstart/cor-site.conf /etc/init/

    # Start the daemon:
    sudo start cor-site
fi