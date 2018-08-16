Projects

japi - .Net Core Web Api
japi.tests - test project to test japi
jui - Web App based on vue js with bootstrap-vue

To build and run

japi

Requirement: .Net Core 2.1

>dotnet restore
>dotnet run

japi.tests

>dotnet restore
>dotnet test

jui

Requirement: latest version of npm

>npm install
>npm build
>npm run dev

Open listed http://localhost:port

japi is using basic authentication at the moment. To run jui with japi locally start chrome as follows 

>google-chrome --disable-web-security --user-data-dir .
