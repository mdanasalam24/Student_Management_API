\# Student Management API



A RESTful Web API built using \*\*ASP.NET Core\*\* that provides CRUD operations for managing student records. This project demonstrates backend development concepts like API routing, dependency injection, repository pattern, and clean project structure.



\## 🚀 Features



\* Create a new student record

\* Get all students

\* Get student details by ID

\* Update student information

\* Delete student record

\* Repository Pattern implementation

\* RESTful API architecture

\* Dependency Injection

\* Clean project structure



\## 🛠️ Technologies Used



\* C#

\* ASP.NET Core Web API

\* .NET 10

\* REST API

\* Visual Studio

\* Git \& GitHub



\## 📂 Project Structure



```text

Student\_Management\_API

│

├── Models

│   └── Student.cs

│

├── Repository

│   └── StudentRepository.cs

│

├── Properties

│

├── Program.cs

│

├── appsettings.json

│

└── Student\_Management\_API.csproj

```



\## 📌 API Endpoints



\### Get All Students



```

GET /api/students

```



Returns all student records.



\---



\### Get Student By ID



```

GET /api/students/{id}

```



Returns student details based on ID.



\---



\### Create Student



```

POST /api/students

```



Example Request:



```json

{

&#x20; "name": "Rahul Kumar",

&#x20; "age": 22,

&#x20; "course": "Computer Science"

}

```



\---



\### Update Student



```

PUT /api/students/{id}

```



Updates existing student information.



\---



\### Delete Student



```

DELETE /api/students/{id}

```



Deletes a student record.



\## ▶️ How To Run The Project



\### Clone Repository



```bash

git clone https://github.com/mdanasalam24/Student\_Management\_API.git

```



\### Open Project



Open the project in Visual Studio.



\### Restore Packages



```bash

dotnet restore

```



\### Run Application



```bash

dotnet run

```



The API will start running on the configured localhost URL.



\## 🔮 Future Improvements



\* Add JWT Authentication and Authorization

\* Add Entity Framework Core Database Integration

\* Add SQL Server Integration

\* Add Global Exception Handling Middleware

\* Add Swagger API Documentation

\* Add Unit Testing

\* Implement DTO Pattern

\* Add Logging



\## 👨‍💻 Author



\*\*MD Anas\*\*



GitHub:

https://github.com/mdanasalam24



\## 📄 License



This project is created for learning and demonstration purposes.



