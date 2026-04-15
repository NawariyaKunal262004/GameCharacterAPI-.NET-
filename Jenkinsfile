pipeline {
  agent any

  environment {
    IMAGE_NAME = "gamecharacterapi"
    TAG = "${env.BUILD_NUMBER}"
    REGISTRY = ""   // set e.g. docker.io/username if needed
  }

  stages {

    stage('Checkout') {
      steps {
        checkout scm
      }
    }

    stage('Restore') {
      steps {
        sh "dotnet restore VideoGameCharacterApi/VideoGameCharacterApi.csproj"
      }
    }

    stage('Build') {
      steps {
        sh "dotnet build VideoGameCharacterApi/VideoGameCharacterApi.csproj --configuration Release --no-restore"
      }
    }

    stage('Test') {
      steps {
        sh "dotnet test VideoGameCharacterApi.Tests/VideoGameCharacterApi.Tests.csproj --no-build --verbosity normal"
      }
    }

    stage('Publish') {
      steps {
        sh "dotnet publish VideoGameCharacterApi/VideoGameCharacterApi.csproj -c Release -o out"
      }
    }

    stage('Docker Build') {
      steps {
        sh "docker build -t ${IMAGE_NAME}:${TAG} ."
      }
    }

    stage('Push') {
      when {
        expression { return env.REGISTRY?.trim() }
      }
      steps {
        sh "docker tag ${IMAGE_NAME}:${TAG} ${REGISTRY}/${IMAGE_NAME}:${TAG}"
        sh "docker push ${REGISTRY}/${IMAGE_NAME}:${TAG}"
      }
    }
  }

  post {
    always {
      echo "Build finished: ${currentBuild.currentResult}"
    }

    success {
      echo "Pipeline SUCCESS"
    }

    failure {
      echo "Pipeline FAILED"
    }
  }
}