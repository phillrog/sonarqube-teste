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
                bat 'dotnet build --configuration Release'
                
            }
        }
        stage('SonarQube analysis') {
			steps {
				bat 'dotnet sonarscanner begin /k:"calculadora" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="8319ba21ba9b1b5c483956987193fbbaeee76790"'
                bat 'dotnet test .\Calculadora.Tests\Calculadora.Tests.csproj --collect:"XPlat Code Coverage" --results-directory ./coverage'
                bat 'reportgenerator "-reports:./coverage/*/coverage.cobertura.xml" "-targetdir:coverage" "-reporttypes:SonarQube"'
                bat 'dotnet sonarscanner end /d:sonar.login="8319ba21ba9b1b5c483956987193fbbaeee76790"'
			}
		}
    }
}