node("docker") {
    checkout scm

    def customImage = docker.build("barrydobson/sa-frontend:${env.BUILD_ID}", "./sa-frontend")
    customImage.push()
    customImage.push('latest')
}