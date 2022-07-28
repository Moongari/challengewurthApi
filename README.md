# Challenge NET 5
_(juste en dessous des badges sympatiques à placer)_

[![forthebadge](http://forthebadge.com/images/badges/built-with-love.svg)](http://forthebadge.com)  [![forthebadge](http://forthebadge.com/images/badges/powered-by-electricity.svg)](http://forthebadge.com)

Cette application permet de créer une API REST via .NET5 et Visual studio community 2022
- un backend qui fournit une API REST pour interagir avec ces données (CRUD)
## Pour commencer

Recuperer le projet via le repository github : https://github.com/Moongari/challengewurthApi.git



### Pré-requis

Ce qu'il est requis pour commencer avec votre projet...

- .NET5
- Utilisation ou installation  du client Postman pour consommer les différents requestes .
- Authentification : les credentials sont présentes dans le fichier appsettings.json
- Visual studio Community 2022
- Installation de sdk .net5 (optionnel)
- Afin de faciliter la mise en place et le lancement de l'application nous gerons une base de données en Memoire

- Dependances suivantes présentent dans le projet  :
	Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 5.0.17

- Les données sont issues d'un fichier data.json pour gerer la deserialisation nous utilisons NewtonSoft.JSon(13.0.1)
		Install-Package Newtonsoft.Json -Version 13.0.1
		
	
- Si vous télécharger a partir de la branche features_test le dossier zip , veuillez placer le dossier MyTravelMicroservice.Test au meme niveau que le dossier
	![2022-07-28 13_52_17-Window](https://user-images.githubusercontent.com/56550445/181498185-988933f5-d024-40f3-9e4e-89e905d3644b.png)


### fonctionnalités utilisées dans le projet Travel

- Generics
- lambda Expression
- LINQ
- Exception Handling
- Asynchronous Programme with Async / await
- API RESTFUL
- Authentification API
- Mise en place 

## PROJET TRAVEL
 
 une fois que vous avez recuperer le projet dans votre repertoire :
 placer vous dans le repertoire du projet "MyTravelMicroservice"
 1° verifier que le sdk est correctement installe avec la commande : dotnet 
 
 vous devriez obtenir ceci a l'affichage dans la console 
 
		Usage: dotnet [options] 
		Usage: dotnet [path-to- application] 


		Options : 
		-h I --help 	Display help. 
		- info 			Display . NET information. 
		-list-sdks  	Display the installed SDKs.
		- -list-runtimes Display the installed runtimes . 
			path- to-application : 	
		 The path to an application . dll file to execute. 	

 2° taper la commande : dotnet run
			
			Lancer Postman et indiquer cette adresse : (attention le numero de port peut etre différent)
			Methode  GET 
			Now listening on: http://localhost:5000/api/travel
			
			Methode GET : id
			http://localhost:5000/api/travel/1
			
			
			information : il existe jusqu'a 1000 enregistrements dans le fichier



	vous desirez integrer cette application dans un conteneur docker voici comment proceder :
	
	ajout du DockerFile 

	Créez un fichier appelé Dockerfile avec cette commande : 

 

	fsutil file createnew Dockerfile 0 

 

	Vous pouvez ensuite l’ouvrir manuellement dans votre éditeur de texte préféré ou avec cette commande:

 

	start Dockerfile 

 

	Copiez ce contenu du Dockerfile par ce qui suit dans l’éditeur de texte :

 

		FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build 
		WORKDIR /src 
		COPY MyTravelMicroservice.csproj . 
		RUN dotnet restore 
		COPY . . 
		RUN dotnet publish -c release -o /app 
		FROM mcr.microsoft.com/dotnet/aspnet:5.0 
		WORKDIR /app 
		COPY --from=build /app . 
		ENTRYPOINT ["dotnet", "MyTravelMicroservice.dll"] 

 

 

	Facultatif : Ajouter un fichier .dockerignore 

	Un fichier .dockerignore réduit l’ensemble des fichiers utilisés dans le cadre de la version docker. Moins de fichiers se traduira par des builds plus rapides. 

	Créez un fichier appelé fichier .dockerignore (similaire à un fichier .gitignore si vous les connaissez) avec cette commande : 

 

	Commande a realiser : 

	fsutil file createnew .dockerignore 0 

	 

	Pour ouvrir le fichier avec un editeur de text de votre choix : 

	start .dockerignore 

 

	Create Docker image 

 

	docker build -t mytravelmicroservice . 

 

 

	La commande docker build utilise dockerfile pour créer une image Docker. 

	Le paramètre -t mytravelmicroservice lui indique de baliser (ou de nommer) l’image en tant que mytravelmicroservice. 

	Le dernier paramètre lui indique le répertoire à utiliser pour trouver le Dockerfile (. spécifie le répertoire actif). 

	Cette commande téléchargera et créera toutes les dépendances pour créer une image Docker et peut prendre un certain temps. 

 

	##Run Docker image 

	You can run your app in a container using the following command: 
	docker run -it --rm -p 3000:80 --name myMyTravelMicroservicecontainer mytravelmicroservice 


## Fabriqué avec
 visual studio 2022


## Versions
.NET CORE 5.0


**Dernière version stable :** 1.0
**Dernière version :** 1.0
Liste des versions : [Cliquer pour afficher](https://github.com/your/project-name/tags)
_(pour le lien mettez simplement l'URL de votre projets suivi de ``/tags``)_

## Auteur

* **Moungari Moustafa ** _alias_ [@Moongari](https://github.com/Moongari)





