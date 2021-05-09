node {
   stage('Build') {
     dotnet build 'src/Tragate.UI/Tragate.UI.csproj'
   }
   stage('Test') {
      dotnet build 'src/Tragate.Tests/Tragate.Tests.csproj'
   }
}