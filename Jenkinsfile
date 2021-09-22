pipeline {
    agent any
    environment {
        nuget = "C:\\jenkins\\nuget.exe"  
    }
    stages {
        stage('Git Checkout') { 
           steps{ 
                bat 'echo Git Checkout'
                git branch: 'main', url: 'https://{auth}@github.com/danielapochini/desafio-automacao-web.git'
            }
        }
        stage('CleanUp Stage') { 
            steps{ 
                bat 'echo CleanUp Stage'
                dotnetClean configuration: 'Debug', project: 'DesafioAutomacaoWeb.sln', sdk: '.NET 5.0', workDirectory: "${WORKSPACE}/DesafioAutomacaoWeb/"
            }
        }
        stage('Restore Package Stage') { 
           steps{ 
                bat 'echo Restore Package Stage'
                dotnetRestore project: 'DesafioAutomacaoWeb.sln', sdk: '.NET 5.0', workDirectory: "${WORKSPACE}/DesafioAutomacaoWeb/"
            } 
        }
        stage('Build Stage') { 
            steps{ 
                bat 'echo build'
                dotnetBuild configuration: 'Debug', project: 'DesafioAutomacaoWeb.sln', sdk: '.NET 5.0', workDirectory: "${WORKSPACE}/DesafioAutomacaoWeb/"
            }
        }
        stage('Test Execution Stage') { 
            steps{ 
                bat 'echo Test Execution Started'
               dotnetTest configuration: 'Debug', project: 'DesafioAutomacaoWeb.sln', sdk: '.NET 5.0', workDirectory: "${WORKSPACE}/DesafioAutomacaoWeb/"
            }
        } 
        stage('Report') {
            steps { 
                dir('C:/jenkins/workspace/DesafioAutomacaoWeb/DesafioAutomacaoWeb/bin/Debug/net5.0'){
                    bat 'echo Generating Report'
                    bat 'livingdoc test-assembly DesafioAutomacaoWeb.dll -t Reports/TestExecution.json --project-language pt-BR -o Reports/'
                } 
                    bat 'echo Publishing HTML Report'
                    publishHTML([allowMissing: false, alwaysLinkToLastBuild: true, keepAll: false, reportDir: 'DesafioAutomacaoWeb/bin/Debug/net5.0', reportFiles: 'LivingDoc.html', reportName: 'LivingDoc Tests HTML Report', reportTitles: ''])
               
            }  
        } 
    } 
}
