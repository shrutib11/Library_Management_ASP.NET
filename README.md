# Library Management System

A simple library management system built in .NET Framework that enables users to manage books, students, and book borrowing operations. 
This application allows users to perform various CRUD (Create, Read, Update, Delete) operations on students and books, as well as issue and return books. 
Additionally, users can view complete details of both books and students.

## Features

- Login
- Add, update, and delete students
- Add, update, and delete books
- View a list of all students
- View a list of all books
- Issue books to students
- Return books from students
- Detailed view of each book's information
- Detailed view of each student's information

## Requirements

- .NET Framework v4.7.2
- SQL Server Management studio v19.1

## Installation

To use the Library Management System, follow these steps:

Clone the repository
git clone https://github.com/shrutib11/Library_Management_ASP.NET

Open in Visual Studio 
Open the solution file (LibraryManagement.sln) in Visual Studio.

Restore NuGet Packages
Right-click on the solution in the Solution Explorer and select "Restore NuGet Packages" to ensure all necessary packages are installed.

Set Up the Database
Open the SQL Server Management Studio.
Create a new database named loginTb.
Run the SQL script file libraryManagement_script.sql located in the repository to create the necessary tables and seed data.

Build the Solution
Build the solution to make sure there are no build errors.

Run the Application
Press F5 or select "Start" to run the application. The system should now be up and running.

