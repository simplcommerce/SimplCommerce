pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/simplcommerce/SimplCommerce.git'
            }
        }
        stage('Build') {
            steps {
                sh 'docker build -t your-docker-repo/user-management:latest .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker run your-docker-repo/user-management:latest npm test'
            }
        }
        stage('SonarQube Analysis') {
            steps {
                // Assuming SonarQube is set up and configured
                withSonarQubeEnv('SonarQube') {
                    sh 'mvn sonar:sonar'
                }
            }
        }
        stage('Push to ECR') {
            steps {
                sh '''
                   aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 008971676730.dkr.ecr.us-east-1.amazonaws.com
                   docker tag your-docker-repo/user-management:latest 008971676730.dkr.ecr.us-east-1.amazonaws.com/user-management:latest
                   docker push 008971676730.dkr.ecr.us-east-1.amazonaws.com/user-management:latest
                '''
            }
        }
    }

    post {
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed.'
        }
    }
}
