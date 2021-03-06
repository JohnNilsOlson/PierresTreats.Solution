# _Pierre's Sweet and Savory Treats_
Epicodus Week 12  
Version 1.0 - August 14, 2020 

## _Project Description_
A practice in many-to-many database relationships and authentication with Identity. 

## _Contributors_
JohnNils Olson

## _Usage_
A webapp for users to create treats and track relationships between treats and flavors for Pierres Bakery.

## _Behavior Specifications_
### If User is not Registered and Logged In ###

| Behavior | Input | Output |
| ---- | ---- | ---- |
| Program Directs to Splash Page | Project URL | List of All Treats and Flavors |
| Program Directs to Treat Details | Link -> "Treat Details" | Redirect -> Treats - Details |
| Program Directs to Flavor Details | Link -> "Flavor Details" | Redirect -> Flavors - Details |
| Program Directs to Accounts | Link -> "Account" | Redirect -> Accounts - Index |
| Program Directs to Register | Link -> "Register" | Redirect -> Accounts - Register |
| User Inputs User Account Info, User Account Added to Database | Submit | Redirect - Accounts - Login |
| User Inputs Login Credentials | Submit | Redirect -> Home - Index |  
  
### If User is Registered and Logged In ###

| Behavior | Input | Output |
| ---- | ---- | ---- |
| Program Directs to Add New Treat | Link -> "Add New Treat" | Redirect -> Treats - Create | 
| User Inputs New Treat Info, Treat Added to Database | Submit | Redirect -> Treats - Index |
| Program Directs to Remove Treat | Link -> "Remove Treat" | Redirect -> Treats - Delete
| User Removes Treat, Treat Removed from Database | Submit | Redirect -> Treats - Index |
| Program Directs to Treat Edit | Link -> "Edit Treat Details" | Redirect -> Treats - Edit |
| User Edits Treat Details, Treat Details Changes Saved to Database | Submit | Redirect -> Treats - Details |
| Program Directs to Add New Flavor  | Link -> "Add New Flavor" | Redirect -> Flavors - Create |
| User Inputs New Flavor Info, Flavor Added to Database | Submit | Redirect -> Treats - Details |
| Program Directs to Remove Flavor | Link -> "Remove Flavor" | Redirect -> Flavors - Delete
| User Removes Flavor, Flavor Removed from Database | Submit | Redirect -> Treats - Details |
| Program Directs to Flavor Edit | Link -> "Edit Flavor Details" | Redirect -> Flavor - Edit |
| User Edits Flavor Details, Flavor Details Changes Saved to Database | Submit | Redirect -> Flavors - Details |
| Program Directs to Add Treat Flavors | Link -> "Add Treat Flavors" | Redirect -> Treat - Add Flavors |
| User Adds Flavors to Treat, Treat Flavors Added to Database | Submit | Redirect -> Treat Details |
| Program Directs to Add Flavor Flavors | Link -> "Add Flavor Flavors" | Redirect -> Flavor - Add Flavors |
| User Adds Flavors to Flavor, Flavor Flavors Added to Database | Submit | Redirect -> Flavor Details |

## _Technologies Used_
C#  
.NETCore  
Entity Framework Core  
MySql Server

## _Installation Instructions_
* Project Cloning instructions.
  1. Open Git Bash.
  2. Change the current working directory to the location where you would like to clone the repository.
  3. Type "git clone" followed by "(https://github.com/JohnNilsOlson/PierresTreats.Solution)" (without quotes) and hit enter.
  4. Open directory with code editor of choice.

* Project Download instructions.
  1. Visit "(https://github.com/JohnNilsOlson/PierresTreats.Solution)".
  2. Click the green "code" button and download zip file of project.
  3. Extract zip file to directory of choice.
  4. Open project directory in code editor of choice.

* Instructions to Set Up Database with MySql Workbench (Required to Run Web App).
  1. In the terminal, change working directory to ./PierresTreats.
  2. Type "dotnet ef database update" to create database schema.

* Instructions to Run WebApp
  1. In the terminal, change working directory to ./PierresTreats.
  2. Type "dotnet restore".
  3. Type "dotnet run".

## _Bugs_
No known issues.

## _Contact Information_
JohnNils Olson - johnnils@gmail.com  

## _License_
The [MIT] license.
Copyright (c) 2020 JohnNils Olson