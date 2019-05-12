import jetbrains.buildServer.configs.kotlin.v2018_2.*
import jetbrains.buildServer.configs.kotlin.v2018_2.buildSteps.dotnetBuild
import jetbrains.buildServer.configs.kotlin.v2018_2.buildSteps.dotnetPublish
import jetbrains.buildServer.configs.kotlin.v2018_2.buildSteps.powerShell
import jetbrains.buildServer.configs.kotlin.v2018_2.buildSteps.script

version = "2018.2"

project {

    buildType(Deploy)
}

object Deploy : BuildType({
    name = "Deploy"

    params {
        password("ssh.port", "credentialsJSON:a5b6c404-3cd6-4a26-82cc-a24cecad8c63")
    }

    vcs {
        root(DslContext.settingsRoot)
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
        powerShell {
            name = "configure"
            workingDir = "bin/release/netcoreapp2.2/publish"
            scriptMode = script {
                content = """
                        ${'$'}config = @'
                        {
                           "CtorSettings":{
                              "LogUrlPrefix": "https://codingteam.org.ru/_logs/codingteam%40conference.jabber.ru",
                              "LogTimeZoneOffset": 4
                           },
                           "Logging":{
                              "IncludeScopes": false,
                              "LogLevel":{
                                 "Default": "Debug",
                                 "System": "Information",
                                 "Microsoft": "Information"
                              }
                           }
                        }
                        '@
                        ${'$'}config | Out-File appsettings.json -Encoding utf8
                    """.trimIndent()
            }
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
            param("jetbrains.buildServer.deployer.sourcePath", "bin/release/netcoreapp2.2/publish/*")
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
})
