node("docker") {
    stage 'Checkout'
        checkout scm

    stage 'Build'
        def customImage = docker.build("barrydobson/sa-frontend:${env.BUILD_ID}", "./sa-frontend")
    
    stage 'Push'
        docker.withRegistry( '', 'dockerhub-bd' ) {
            customImage.push()
            customImage.push('latest')
        }

    stage 'Clean up'
        sh "docker rmi barrydobson/sa-frontend:${env.BUILD_ID}"
}