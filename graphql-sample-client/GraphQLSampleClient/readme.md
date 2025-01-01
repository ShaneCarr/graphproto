dotnet package add Microsoft.Extensions.DependencyInjection
dotnet graphql init http://localhost:4000/graphql
dotnet add package StrawberryShake.CodeGeneration.CSharp --version 14.3.0\ndotnet add package StrawberryShake.Transport.Http --version 14.3.0
dotnet build
dotnet graphql generate

which uses the .graphqlrc.json file to generate clients from included graphql in selected folder

