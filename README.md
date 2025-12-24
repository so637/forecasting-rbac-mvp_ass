Forecasting & RBAC MVP
About the Task

This is a simple full-stack MVP built using React and ASP.NET Core Web API.

The goal of this Task is to show:

Role-based access control (RBAC)

CSV upload

Forecast generation

Approval workflow for forecast changes

The focus is on logic and architecture, not UI design.

Tech Stack

Frontend: React

Backend: ASP.NET Core Web API

Database: SQLite (Entity Framework Core)

User Roles

Admin

Manager

User

Roles are checked on the backend using request headers.

How Login Works

Static users are stored in the database

Login returns user role

Role is sent in API requests using header:

X-User-Role

CSV Upload

Admin can upload a CSV file

CSV data is stored as raw text

Example CSV used:

Value
100
200
150

Forecast Logic

After CSV upload, Admin generates forecast

Forecast is created for next 12 months

Simple average-based logic is used

One record per month is stored

Approval Workflow

Users and Managers can propose forecast changes

Original forecast is not updated

A new commitment record is created

Status: Pending / Approved / Rejected

Admin or Manager approves the change

Database Tables

CsvImports – stores uploaded CSV

SimulatedProjects – stores system forecast

UserCommitments – stores user changes

How to Run
Backend
cd Forecast.Api
dotnet run

Frontend
cd forecast-ui
npm start

Test Users
Role	Username	Password
Admin	admin	admin123
Manager	manager	manager123
User	user	user123