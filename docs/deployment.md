codingteam.org.ru site deployment
=================================

This page documents our current production environment and process of deploying
the site to it.

Target environment
------------------

codingteam.org.ru targets Linux Ubuntu 16.04. There should be a `cor-site` user
on the target machine, and he should have full access to
`/opt/codingteam/codingteam.org.ru` directory.

Save the following systemd configuration as `/etc/systemd/system/cor-site.service`:

```
[Unit]
Description=codingteam.org.ru site
After=network.target

[Service]
User=cor-site
WorkingDirectory=/opt/codingteam/codingteam.org.ru/
ExecStart=/usr/bin/dotnet /opt/codingteam/codingteam.org.ru/codingteam.org.ru.dll

[Install]
WantedBy=multi-user.target
```

The service should be enabled by `sudo systemctl enable cor-site`.

CI environment
--------------

There is a Jenkins CI server set up to deploy `master` branch when any
maintainer decides it's time to release.

[Jenkins pipeline plugin][jenkins-pipeline-plugin] controls the build process.
Make sure it's installed and all dependencies are met. Consult
`scripts/Jenkinsfile.deploy` and set up all the build parameters on your server.

The deployment is performed over SSH, so make sure that CI server have SSH
access to the target machine as the same `cor-site` user, and that `cor-site`
has permissions to execute the commands `sudo /bin/systemctl start cor-site`
and `sudo /bin/systemctl stop cor-site` (and nothing else).

[dotnet]: https://dot.net/
[jenkins-pipeline-plugin]: https://wiki.jenkins-ci.org/display/JENKINS/Pipeline+Plugin
