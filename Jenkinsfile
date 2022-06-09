node ('Principal') {
       stage('SCM'){
		checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[url: 'https://github.com/josmilla/APIClient2022']]])
	}
	stage('Build'){
		try{
		sh 'dotnet build APIClient'
		}finally{
		archiveArtifacts artifacts: 'APIClient/*.*'
		}
	}
	stage('Test'){
		echo 'Execute unit tests'
	}
	stage('Package'){
		echo 'Zip it up'
	}
	stage('Deploy'){
		echo 'Push to deployment'
	}
	stage('Archive'){
		archiveArtifacts artifacts: 'APIClient/*.*'
	}
}
