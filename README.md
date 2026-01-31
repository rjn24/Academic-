# Academic Class & Course Management System  
ASP.NET Core Web API + Angular Frontend (Full Stack)

This project is a full-stack web application to manage academic Classes and Courses.

It allows you to:
- Create, update and delete Classes
- Create, update and delete Courses
- View Classes and Courses separately
- View a combined (joined) Class + Course table based on semester
- Interact with a .NET backend API from an Angular UI

The backend is built with ASP.NET Core and Entity Framework Core.  
The frontend is built with Angular (standalone components, no AppModule).

---

## Demo Video

[![Watch the demo](https://img.youtube.com/vi/eVkyXZo9n4k/0.jpg)](https://youtu.be/eVkyXZo9n4k)

This video shows:
- Adding, editing and deleting Classes
- Adding, editing and deleting Courses
- Toggling the different tables in the UI
- The joined Class + Course view

---

## Tech Stack

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- CORS enabled for Angular dev server
- Swagger for API testing and documentation

### Frontend
- Angular
- Standalone Components
- Angular Router
- Angular Forms (ngModel)
- HttpClient + Observables (RxJS)

---

## Project Structure

WebApplication1/
│
├── WebApplication1/ # ASP.NET Core backend
│ ├── Controllers
│ ├── Models (Class, Course)
│ ├── ApplicationDbContext
│ └── Program.cs
│
└── frontend/class-course-ui/ # Angular frontend
├── src/app/class-courses # main UI component
├── academic.service.ts # API service
└── routing & bootstrap files


---

## Features

### Classes CRUD
- Add new class
- Edit existing class
- Delete class
- Show/Hide and Refresh table

Fields:
- ClassID
- Program
- Year
- Section
- Semester

### Courses CRUD
- Add new course
- Edit existing course
- Delete course
- Show/Hide and Refresh table

Fields:
- CourseCode
- SubjectName
- Semester
- Credits

### Joined View (Read Only)
- Combines Classes and Courses
- Client-side join on matching Semester
- Used only for display, no CRUD

---

## How It Works (Flow)

1. Angular button click calls a method in the component.
2. Component calls a method in `AcademicService`.
3. `AcademicService` sends HTTP request using `HttpClient`.
4. ASP.NET Core controller receives the request.
5. Entity Framework Core reads/writes data to SQL Server.
6. JSON response is returned to Angular.
7. Angular updates the table using the new data.

---

## Backend API Endpoints

Classes:
GET /api/Academic/classes
GET /api/Academic/classes/{id}
POST /api/Academic/classes
PUT /api/Academic/classes/{id}
DELETE /api/Academic/classes/{id}


Courses:
GET /api/Academic/courses
GET /api/Academic/courses/{code}
POST /api/Academic/courses
PUT /api/Academic/courses/{code}
DELETE /api/Academic/courses/{code}


---

## Running the Project Locally

### 1. Backend (.NET)

1. Open the backend project in Visual Studio
2. Update connection string in `appsettings.json` if needed
3. Run the project

API will run on something like:
https://localhost:7004


Swagger UI:
https://localhost:7004/swagger


---

### 2. Frontend (Angular)

Open terminal inside:

frontend/class-course-ui


Install dependencies:
```bash
npm install
Run Angular dev server:

ng serve
Open in browser:

http://localhost:4200
Make sure backend is running before using the UI.

CORS Configuration
Backend allows Angular dev server:

.WithOrigins("http://localhost:4200")
.AllowAnyHeader()
.AllowAnyMethod();
This enables the Angular app to call the API from the browser.

Important Concepts Used
Dependency Injection in ASP.NET Core and Angular

Async/await for non-blocking database calls

Entity Framework Core change tracking

RESTful HTTP status codes (201 Created, 204 NoContent, 404 NotFound)

Angular two-way binding with [(ngModel)]

Observables and subscribe() for HTTP calls

Conditional rendering with Angular control flow (@if, @for)

Future Improvements
Server-side join endpoint instead of client nested loops

Pagination and search

Validation and error messages in UI

Authentication and authorization (JWT)

Deployment to cloud (Azure / GitHub Pages for frontend)

Author
Rajan
Full-stack ASP.NET Core + Angular project for academic management.
