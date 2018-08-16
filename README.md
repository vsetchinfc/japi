<h1>Projects</h1>

japi - .Net Core Web Api<br>
japi.tests - test project to test japi<br>
jui - Web App based on vue js with bootstrap-vue<br>

<h2>To build and run</h2>

<h3>japi</h3>

<i>Requirement: .Net Core 2.1</i>

>dotnet restore<br>
>dotnet run

<h3>japi.tests</h3>

>dotnet restore<br>
>dotnet test

<h3>jui</h3>

<i>Requirement: latest version of npm</i>

>npm install<br>
>npm build<br>
>npm run dev

Open listed http://localhost:port

japi is using basic authentication at the moment. To run jui with japi locally start chrome as follows 

>google-chrome --disable-web-security --user-data-dir .
