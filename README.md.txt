📌 Task Management Application

A full-stack Task Management Application with JWT Authentication, built using:

Frontend: React (Redux Toolkit + Axios)

Backend: ASP.NET Core .NET 8 Web API

Database: SQL Server

Authentication: JWT (Role-based)

Logging: log4net

Project Structure
==========================================
frontend               # React app
================================================
src/
│
├── api/
│   └── httpClient.tsx
│
├── app/
│   ├── hooks.ts
│   └── store.ts
│
├── assets/
│   └── images, icons, static files
│
├── auth/
│   ├── authSlice.tsx
│   ├── Login.tsx
│   ├── Register.tsx
│   ├── Header.tsx
│   ├── Login.css
│   ├── Auth.css
│   └── Header.css
│
├── routes/
│   └── (routing related files if used)
│
├── tasks/
│   ├── taskSlice.tsx
│   ├── TaskPage.tsx
│   ├── TaskList.tsx
│   ├── TaskForm.tsx
│   ├── TaskFilter.tsx
│   └── Task.css
│
├── App.tsx
├── App.css
└── main.tsx

=================================================
├── backend/                 # ASP.NET Core API
│   TaskManagementApplication
│
├── Connected Services        # External services (rarely used here)
├── Dependencies              # NuGet packages
├── Properties                # launchSettings.json
│
├── Controllers               # API endpoints (Auth, Tasks)
├── DTOs                      # Request/Response models
├── Helpers                   # JWT, PasswordHash, Utilities
├── Models                    # DB entities
├── Repository                # Dapper / DB access layer
│
├── appsettings.json          # DB + JWT configuration
├── log4net.config            # Logging configuration
└── Program.cs                # App startup
=======================================================
├── database/
│   ├── TaskManagementDB.sql           # DB script
│   
│
└── README.md

 FRONTEND SETUP (React + Vite + TypeScript)
 Prerequisites
===========================================
Node.js 18+

npm 9+

 Create React Project
npm create vite@latest frontend




 Install Dependencies
====================

npm install
npm install axios @reduxjs/toolkit react-redux react-toastify

 Run React App
==============
npm run dev


Frontend will run at:
====================

http://localhost:5173

Frontend Features
==================

Login & Registration

JWT token handling

Axios interceptor (401 / 403)

Task CRUD

Role-based delete (Admin only)

Toast notifications

Form validation

 BACKEND SETUP (.NET 8 Web API)
===============================
Prerequisites

.NET SDK 8.0

SQL Server 2019+

Create API Project


 Required Packages
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
dotnet add package log4net
dotnet add package Microsoft.Extensions.Logging.Log4Net.AspNetCore


app.UseAuthentication();
app.UseAuthorization();

 Run API
=================
Visual Studio run


Backend runs at:
=====================================

https://localhost:44397/swagger/index.html

DATABASE SETUP (SQL Server)
==============================================================
Run the attached script file in SQL Server Management Studio (SSMS).

 DATABASE BACKUP & RESTORE
 Backup
BACKUP DATABASE TaskManagementDB
TO DISK = 'C:\Backup\TaskManagementDB.bak'
WITH INIT;


AUTHORIZATION RULES
========================================
Role	Permission
User	Create / View / Edit tasks
Admin	Full access (Delete allowed)

DEFAULT TEST USER
-----------------
Username: admin
Password: admin
Role: Admin


Username: user
Password: user
Role: User


LOGGING (log4net)
==========================================
Logs stored at:

bin/Debug/net8.0/Logs/app.log


Configured using log4net.config.



 RUN ORDER (VERY IMPORTANT)

1️⃣ Start SQL Server
2️⃣ Run backend (dotnet run)
3️⃣ Run frontend (npm run dev)
4️⃣ Login → Manage Tasks