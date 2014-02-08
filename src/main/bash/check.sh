#!/bin/sh
oldVersion=`git rev-parse HEAD`
git pull origin master
newVersion=`git rev-parse HEAD`

if [ $oldVersion != $newVersion ]
then
    # Stop the daemon:
    sudo stop cor-site

    # Build new version:
    # TODO: -mem setting for both sbt invocations
    sbt clean
    # TODO: copy artifact to target directory
    sbt assembly

    # Replace the daemon script:
    cp src/main/upstart/cor-site.conf /etc/init/

    # Start the daemon:
    sudo start cor-site
fi