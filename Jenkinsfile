pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:5.0'
      registryUrl 'https://index.docker.io/v1/'
    }
  }
  stages {
    stage('Build') {
      steps {
        sh 'dotnet build APIClient/APIClient.csproj -c Release -o /app'
      }
    }
    stage('Test') {
      steps {
        sh 'dotnet test APIClient/APIClient.csproj -c Release -r /results'
      }
    }
  }
}
