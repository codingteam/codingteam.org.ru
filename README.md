codingteam.org.ru
=================
This is the code meant to service the http://codingteam.org.ru site.

### Building
This project uses the `sbt` build system. So you should be able to run

    sbt assembly

to build the project deployment-ready JAR package.

### Deployment
1. Create a user for project.
2. Give an access for starting and stopping the `cor-site` daemon to user.
3. Clone git repository to some location that the user can access.
4. Set up the `src/main/bash/check.sh` script for running as a `cron` job. Its working directory should be the git repository.