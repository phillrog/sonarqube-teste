pipeline {
    agent any
    stages {        
        stage('Restore packages') {
            steps {
                bat "dotnet restore ${workspace}\\sonarqube-teste\\calculadora.sln"
            }
        }  
    }
}