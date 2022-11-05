pipeline {
    agent any
    stages {        
        stage('Restore packages') {
            steps {
                bat "dotnet restore ${workspace}\\calculadora.sln"
            }
        }
        stage('Build') {
            steps {
                bat 'dotnet tool install --global dotnet-sonarscanner'
                bat 'dotnet sonarscanner begin /k:"calculadora" /d:sonar.host.url="${url_sonar}"  /d:sonar.login="${login_sonar}"'
                bat 'dotnet build --configuration Release'
                bat 'dotnet sonarscanner end /d:sonar.login="${login_sonar}"'
            }
        }
    }
}