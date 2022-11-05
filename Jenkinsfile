pipeline {
    agent any
    stages {        
        stage('Restore packages') {
            steps {
                bat "dotnet restore ${workspace}\\calculadora.sln"
            }
        }
        stage('SonarQube analysis') {
			steps {
				bat 'dotnet sonarscanner begin /k:"calculadora" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="8319ba21ba9b1b5c483956987193fbbaeee76790"'
			}

		}
        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
                bat 'dotnet sonarscanner end /d:sonar.login="8319ba21ba9b1b5c483956987193fbbaeee76790"'
            }
        }
    }
}