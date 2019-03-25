node("docker") {
    
    def commitHash
    def frontEndImage
    def webAppImage
    def logicImage

    stage('Checkout') {
        commitHash = checkout(scm).GIT_COMMIT[0..7]
    }

    stage('Build Front End') {
        frontEndImage = docker.build("barrydobson/sa-frontend:${commitHash}", "./sa-frontend")
    }

    stage('Push Front End') {
        docker.withRegistry( '', 'dockerhub-bd' ) {
            frontEndImage.push()
            frontEndImage.push('latest')
        }
    }

    stage('Build API') {
        webAppImage = docker.build("barrydobson/sa-webapp:${commitHash}", "./sa-webapp")
    }

    stage('Push API') {
        docker.withRegistry( '', 'dockerhub-bd' ) {
            webAppImage.push()
            webAppImage.push('latest')
        }
    }

    stage('Build Logic API') {
        logicImage = docker.build("barrydobson/sa-logic:${commitHash}", "./sa-logic")
    }

    stage('Push Logic API') {
         docker.withRegistry( '', 'dockerhub-bd' ) {
            logicImage.push()
            logicImage.push('latest')
        }
    }
    
    stage('Clean up') {
        sh "docker rmi barrydobson/sa-frontend:${commitHash}"
        sh "docker rmi barrydobson/sa-webapp:${commitHash}"
        sh "docker rmi barrydobson/sa-logic:${commitHash}"
    }
}