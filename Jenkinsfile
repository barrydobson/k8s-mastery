node("docker") {
    stage 'Checkout'
        checkout scm

    stage 'Build Front End'
        def frontEndImage = docker.build("barrydobson/sa-frontend:${env.GIT_REVISION[0..7]}", "./sa-frontend")

    stage 'Push Front End'
        docker.withRegistry( '', 'dockerhub-bd' ) {
            frontEndImage.push()
            frontEndImage.push('latest')
        }

    stage 'Build API'
        def webAppImage = docker.build("barrydobson/sa-webapp:${env.GIT_REVISION[0..7]}", "./sa-webapp")

    stage 'Push API'
        docker.withRegistry( '', 'dockerhub-bd' ) {
            webAppImage.push()
            webAppImage.push('latest')
        }

    stage 'Build Logic API'
        def logicImage = docker.build("barrydobson/sa-logic:${env.GIT_REVISION[0..7]}", "./sa-logic")

    stage 'Push Logic API'
         docker.withRegistry( '', 'dockerhub-bd' ) {
            logicImage.push()
            logicImage.push('latest')
        }

    stage 'Clean up'
        sh "docker rmi barrydobson/sa-frontend:${env.GIT_REVISION[0..7]}"
        sh "docker rmi barrydobson/sa-webapp:${env.GIT_REVISION[0..7]}"
        sh "docker rmi barrydobson/sa-logic:${env.GIT_REVISION[0..7]}"
}