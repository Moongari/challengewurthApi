# Challenge NET 5


[![forthebadge](http://forthebadge.com/images/badges/built-with-love.svg)](http://forthebadge.com)  [![forthebadge](http://forthebadge.com/images/badges/powered-by-electricity.svg)](http://forthebadge.com)

Cette application permet de créer une API REST via .NET5 et Visual studio community 2022
- un backend qui fournit une API REST pour interagir avec ces données (CRUD)
## Pour commencer

- Vous pouvez obtenir le projet via le repository github : https://github.com/Moongari/challengewurthApi.git 
et faire un download du fichier .ZIP



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
		
	


### fonctionnalités utilisées dans le projet Travel

- Generics
- lambda Expression
- LINQ
- Asynchronous Programme with Async / await
- API RESTFUL
- Authentification API
- Controller requetes (GET,POST,PUT,DELETE)


## PROJET Travel
 
 Une fois que vous avez recuperer le projet dans votre repertoire :
 placer vous dans le repertoire du projet "MyTravelMicroservice"
 1° verifier que le sdk est correctement installé : 
 	Commande a realiser :
 	dotnet 
 
 Vous devriez obtenir ceci a l'affichage dans la console 
 
		Usage: dotnet [options] 
		Usage: dotnet [path-to- application] 


		Options : 
		-h I --help 	Display help. 
		- info 			Display . NET information. 
		-list-sdks  	Display the installed SDKs.
		- -list-runtimes Display the installed runtimes . 
			path- to-application : 	
		 The path to an application . dll file to execute. 	

 2° Tapez la commande :   dotnet run
			
			Lancer Postman et indiquer cette adresse : (attention le numero de port peut etre différent)
			Methode  GET 
			Now listening on: http://localhost:5000/api/travel
			
			Methode GET : id
			http://localhost:5000/api/travel/1
			
			
			information : il existe jusqu'a 1000 enregistrements dans le fichier



	Vous desirez integrer cette application dans un conteneur docker voici comment proceder :
	
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
		Dockerfile
		[b|B]in
		[O|o]bj
 

	Create Docker image 

 	
	Créer un dossier mytravelmicroservice
	
	docker build -t mytravelmicroservice . 

 

 

	La commande docker build utilise dockerfile pour créer une image Docker. 

	Le paramètre -t mytravelmicroservice lui indique de baliser (ou de nommer) l’image en tant que mytravelmicroservice. 

	Le dernier paramètre lui indique le répertoire à utiliser pour trouver le Dockerfile (. spécifie le répertoire actif). 

	Cette commande téléchargera et créera toutes les dépendances pour créer une image Docker et peut prendre un certain temps. 

 

	##Run Docker image 

	Vous pouvez exécuter votre application dans un conteneur à l’aide de la commande suivante :
	docker run -it --rm -p 3000:80 --name MyTravelMicroservicecontainer mytravelmicroservice 

	
## Arborescence du projet 

	
![2022-07-27 17_23_49-MyTravelMicroservice](https://user-images.githubusercontent.com/56550445/181286494-a2fb7289-9505-422d-ae1f-072efb9e7092.png)

## Lancement de l'application dans Docker 

![2022-07-27 17_27_53-Containers - Docker Desktop](https://user-images.githubusercontent.com/56550445/181287463-e602540a-5eab-4c40-8eb5-17fcf0845bd8.png)

![2022-07-27 17_32_46-C__Windows_System32_cmd exe](https://user-images.githubusercontent.com/56550445/181287989-ec93cc45-8c02-4ff2-8075-15a9c8800763.png)

![2022-07-27 17_29_50-Postman](https://user-images.githubusercontent.com/56550445/181287576-a8c1e758-3ee9-4c01-801e-8e34b37c2f22.png)
![2022-07-27 17_30_11-Postman](https://user-images.githubusercontent.com/56550445/181287598-9a9b8962-87e7-4a50-8866-6aeb35dc5f6c.png)

## Fabriqué avec
 visual studio 2022


## Versions
.NET CORE 5.0


**Dernière version stable :** 1.0
**Dernière version :** 1.0
Liste des versions : [Cliquer pour afficher](https://github.com/your/project-name/tags)
_(pour le lien mettez simplement l'URL de votre projets suivi de ``/tags``)_

## Auteurs

* **Moungari Moustafa ** _alias_ [@Moongari](https://github.com/Moongari)






