pipeline {
    agent any
    stages {
        stage('Limpar WS') {
            steps {
                cleanWs()
            }
        }     
        stage('Restore packages') {
            steps {
                bat "dotnet restore ${workspace}\\calculadora.sln"
            }
        }  
    }
}