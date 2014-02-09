#!/bin/sh
oldVersion=`git rev-parse HEAD`
git pull
newVersion=`git rev-parse HEAD`

if [ $oldVersion != $newVersion ]
then
    # Stop the daemon:
    sudo stop cor-site

    # Build new version:
    sbt clean -mem 128
    sbt assembly -mem 128

    # Start the daemon:
    sudo start cor-site
fi