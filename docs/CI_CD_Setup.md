CI/CD Setup Guide (Ubuntu WSL + Jenkins)

1. Install dependencies in WSL (Ubuntu):

sudo apt update
sudo apt install -y openjdk-11-jdk apt-transport-https ca-certificates curl gnupg lsb-release docker.io docker-compose

2. Install Jenkins:

wget -q -O - https://pkg.jenkins.io/debian/jenkins.io.key | sudo apt-key add -
sudo sh -c 'echo deb https://pkg.jenkins.io/debian binary/ > /etc/apt/sources.list.d/jenkins.list'
sudo apt update
sudo apt install -y jenkins

3. Start Jenkins and enable on boot:

sudo systemctl start jenkins
sudo systemctl enable jenkins

4. Access Jenkins: open http://localhost:8080 and follow setup wizard. Install suggested plugins.

5. Configure Jenkins:
- Install Docker plugin, Git plugin, Pipeline plugin.
- Add Docker host permissions for the Jenkins user: sudo usermod -aG docker jenkins

6. Create a new Pipeline job and point it at your GitHub repo. Add credentials if private.

7. Add webhooks in GitHub: Settings -> Webhooks -> Add webhook. Use your Jenkins endpoint: http://<your-host>/github-webhook/

8. The provided `Jenkinsfile` will run the pipeline steps: restore, build, test, docker build, and optionally push.

Notes:
- In WSL, running Docker may require Docker Desktop for Windows or configuring Docker Engine to be accessible.
- For production, use a dedicated CI server or cloud service (GitHub Actions, Azure Pipelines) instead of WSL.
