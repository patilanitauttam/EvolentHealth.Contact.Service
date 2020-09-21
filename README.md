## General info
This project is simple maintain contact details.
	
## Technologies
Project is created with:
* .Net Core 3.1
*  Angular 7
	
## Setup
Angular project, install it locally using npm:

## Run 
To run angular project using ng serve --open

## Folder structure

1) Backend Applcation
 - 4 folder structure
   1. EvolentHealth.Contact.Service - contains the api 
   2. EvolentHealth.Contact.Business - write business call and call db related functionality
   3. EvolentHealth.Contact.DataAccess - Which contains database related operations
   4. EvolentHealth.Contact.Common - which code which is used in above 3 project
   
 - In this project used following design pattern
   1. Dependency injection
   2. Generic repository pattern
 
 - In this project used automapper to map the model. 

