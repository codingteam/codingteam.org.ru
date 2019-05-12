import jetbrains.buildServer.configs.kotlin.v2018_2.*
import jetbrains.buildServer.configs.kotlin.v2018_2.buildSteps.dotnetBuild
import jetbrains.buildServer.configs.kotlin.v2018_2.buildSteps.dotnetPublish
import jetbrains.buildServer.configs.kotlin.v2018_2.buildSteps.script
import jetbrains.buildServer.configs.kotlin.v2018_2.triggers.vcs
import jetbrains.buildServer.configs.kotlin.v2018_2.vcs.GitVcsRoot

/*
The settings script is an entry point for defining a TeamCity
project hierarchy. The script should contain a single call to the
project() function with a Project instance or an init function as
an argument.

VcsRoots, BuildTypes, Templates, and subprojects can be
registered inside the project using the vcsRoot(), buildType(),
template(), and subProject() methods respectively.

To debug settings scripts in command-line, run the

    mvnDebug org.jetbrains.teamcity:teamcity-configs-maven-plugin:generate

command and attach your debugger to the port 8000.

To debug in IntelliJ Idea, open the 'Maven Projects' tool window (View
-> Tool Windows -> Maven Projects), find the generate task node
(Plugins -> teamcity-configs -> teamcity-configs:generate), the
'Debug' option is available in the context menu for the task.
*/

version = "2018.2"

project {

    vcsRoot(HttpsGithubComCodingteamCodingteamOrgRuGitRefsHeadsMaster)

    buildType(Deploy)
}

object Deploy : BuildType({
    name = "Deploy"

    params {
        password("ssh.port", "credentialsJSON:a5b6c404-3cd6-4a26-82cc-a24cecad8c63")
    }

    vcs {
        root(HttpsGithubComCodingteamCodingteamOrgRuGitRefsHeadsMaster)
    }

    steps {
        script {
            name = "frontend.restore"
            scriptContent = "npm install"
        }
        script {
            name = "frontend.build"
            scriptContent = "npm run build"
        }
        dotnetBuild {
            name = "backend.build"
            param("dotNetCoverage.dotCover.home.path", "%teamcity.tool.JetBrains.dotCover.CommandLineTools.DEFAULT%")
        }
        dotnetPublish {
            name = "publish"
            configuration = "Release"
            param("dotNetCoverage.dotCover.home.path", "%teamcity.tool.JetBrains.dotCover.CommandLineTools.DEFAULT%")
        }
        step {
            name = "remote.stop"
            type = "ssh-exec-runner"
            param("jetbrains.buildServer.deployer.username", "cor-site")
            param("jetbrains.buildServer.sshexec.command", "sudo /bin/systemctl stop cor-site")
            param("jetbrains.buildServer.sshexec.port", "%ssh.port%")
            param("teamcitySshKey", "cor-site")
            param("jetbrains.buildServer.deployer.targetUrl", "codingteam.org.ru")
            param("jetbrains.buildServer.sshexec.authMethod", "UPLOADED_KEY")
        }
        step {
            name = "remote.upload"
            type = "ssh-deploy-runner"
            param("jetbrains.buildServer.deployer.username", "cor-site")
            param("jetbrains.buildServer.sshexec.port", "%ssh.port%")
            param("teamcitySshKey", "cor-site")
            param("jetbrains.buildServer.deployer.sourcePath", "bin/release/netcoreapp1.1/publish/*")
            param("jetbrains.buildServer.deployer.targetUrl", "codingteam.org.ru:/opt/codingteam/codingteam.org.ru")
            param("jetbrains.buildServer.sshexec.authMethod", "UPLOADED_KEY")
            param("jetbrains.buildServer.deployer.ssh.transport", "jetbrains.buildServer.deployer.ssh.transport.scp")
        }
        step {
            name = "remote.start"
            type = "ssh-exec-runner"
            param("jetbrains.buildServer.deployer.username", "cor-site")
            param("jetbrains.buildServer.sshexec.command", "sudo /bin/systemctl start cor-site")
            param("jetbrains.buildServer.sshexec.port", "%ssh.port%")
            param("teamcitySshKey", "cor-site")
            param("jetbrains.buildServer.deployer.targetUrl", "codingteam.org.ru")
            param("jetbrains.buildServer.sshexec.authMethod", "UPLOADED_KEY")
        }
    }

    triggers {
        vcs {
        }
    }
})

object HttpsGithubComCodingteamCodingteamOrgRuGitRefsHeadsMaster : GitVcsRoot({
    name = "github/codingteam.org.ru"
    url = "https://github.com/codingteam/codingteam.org.ru.git"
    branch = "refs/heads/feature/teamcity"
})
