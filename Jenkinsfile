pipeline {
  agent any

  environment {
    REGISTRY = '' // optional container registry
    IMAGE_NAME = "gamecharacterapi"
    TAG = "${env.BUILD_NUMBER}"
  }

  stages {
    stage('Checkout') {
      steps {
        checkout scm
      }
    }

    stage('Restore') {
      steps {
        sh "dotnet build VideoGameCharacterApi/VideoGameCharacterApi.csproj --configuration Release"
      }
    }

    stage('Build') {
      steps {
        dir('VideoGameCharacterApi') {
            sh "dotnet build --configuration Release"
        }
      }
    }

    stage('Test') {
      steps {
        sh 'dotnet test --no-build --verbosity normal'
      }
    }

    stage('Docker Build') {
      steps {
        sh 'docker build -t ${IMAGE_NAME}:${TAG} .'
      }
    }

    stage('Push') {
      when {
        expression { env.REGISTRY != '' }
      }
      steps {
        sh 'docker tag ${IMAGE_NAME}:${TAG} ${REGISTRY}/${IMAGE_NAME}:${TAG}'
        sh 'docker push ${REGISTRY}/${IMAGE_NAME}:${TAG}'
      }
    }
  }
}
