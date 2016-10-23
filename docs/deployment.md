codingteam.org.ru site deployment
=================================

This page documents our current production environment and process of deploying
the site to it.

Target environment
------------------

codingteam.org.ru targets Linux Ubuntu 14.04. There should be `cor-site` user
created on the target machine, and he should have full access to
`/opt/codingteam/codingteam.org.ru` directory.

Save the following upstart configuration as `/etc/init/cor-site.conf`:

```
start on (local-filesystems and net-device-up IFACE!=lo)
setuid cor-site
chdir /opt/codingteam/codingteam.org.ru/
exec dotnet /opt/codingteam/codingteam.org.ru/codingteam.org.ru.dll
```

CI environment
--------------

There is a Jenkins CI server set up to deploy `master` branch when any
maintainer decides it's time to release.

[Jenkins pipeline plugin][jenkins-pipeline-plugin] controls the build process.
Make sure it's installed and all dependencies are met. Consult
`scripts/Jenkinsfile.deploy` and set up all the build parameters on your server.

The deployment is performed over SSH, so make sure that CI have SSH access to
the target machine as the same `cor-site` user and a permission to execute
`sudo /sbin/stop cor-site` and `sudo /sbin/start cor-site` commands (and nothing
else).

[dotnet]: https://dot.net/
[jenkins-pipeline-plugin]: https://wiki.jenkins-ci.org/display/JENKINS/Pipeline+Plugin
