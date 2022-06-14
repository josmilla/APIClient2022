@Library('jenkins-sharedlib@feature/modularization-net-core')
import sharedlib.NetCoreJenkinsUtil
def utils = new NetCoreJenkinsUtil(this)
/* Project settings */
def project="NET5"

def recipients=""
def deploymentEnvironment="dev"
try {
   node {
      stage('Preparation') {
        cleanWs()
        utils.notifyByMail('START',recipients)
        checkout scm
        utils.prepare()
        //Setup parameters
        env.project="${project}"
        env.deploymentEnvironment = "${deploymentEnvironment}"
        utils.setNetCoreVersion("NETCORE_5")
       
      } 
      stage('Build & U.Test') {
        utils.build("/p:PublishProfile=WebDeploy")
      }
      stage('QA Analisys') {
        utils.executeQA()
      }
      stage('SAST Analisys') {
        utils.executeSast()
      }
      stage('Upload Artifact') {
        utils.uploadArtifact()
      }
      stage('Save Results') {
        utils.saveResult('zip')
      }

 

      stage ('Delivery to DEV'){
        
           def parameters = [
             webAppParameters : [
            //   resourceGroupName : "rsgreu2e193d01",
           //    webAppName: "wappeu2e193d01",     
             ]
           ]
           utils.deployWebApp(parameters)
         }
      
      stage('Post Execution') {
        utils.executePostExecutionTasks()
        utils.notifyByMail('SUCCESS',recipients)
      }
   }
} 
catch(Exception e) {
   node{
      utils.executeOnErrorExecutionTasks()
      utils.notifyByMail('FAIL',recipients)
    throw e
   }
}
