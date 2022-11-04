pipeline {
    agent any
    stages {        
        stage('Restore packages') {
            steps {
                bat "dotnet restore ${workspace}\\calculadora.sln"
            }
        }  
    }
}