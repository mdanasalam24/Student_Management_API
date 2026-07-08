# Student Management API

A backend Web API project built using **ASP.NET Core Minimal API** to manage student records.
This project demonstrates HTTP request/response handling, custom middleware pipeline, repository pattern, LINQ operations, and CRUD operations using an in-memory data repository.

---

## 🚀 Features

### Student Management

* Get all student records
* Get student by ID
* Filter students by course
* Filter students based on fees
* Add new student
* Update existing student
* Delete student

### Middleware Implementation

Custom middleware is implemented for:

* Request logging
* Request path and HTTP method tracking
* Response status code logging
* Request execution time calculation
* Route validation
* Maintenance mode handling
* Header-based authentication

### Request Validation

* Handles invalid routes
* Handles unsupported HTTP methods
* Returns appropriate HTTP status codes

---

## 🛠️ Technologies Used

* C#
* ASP.NET Core Minimal API
* .NET 10
* HTTP Request/Response
* Custom Middleware
* LINQ
* JSON Serialization
* Git & GitHub

---

## 📂 Project Structure

```text
Student_Management_API

│
├── Models
│   └── Student.cs
│
├── Repository
│   └── StudentRepository.cs
│
├── Program.cs
│
├── appsettings.json
│
└── Student_Management_API.csproj
```

---

# 📌 API Endpoints

Base Route:

```
/students
```

---

## Get All Students

### Request

```
GET /students
```

Returns all available student records.

---

## Get Student By ID

### Request

```
GET /students?id=1
```

Returns student details based on ID.

---

## Filter Students By Course

### Request

```
GET /students?Course=BCA
```

Returns students belonging to a specific course.

---

## Filter Students By Fees

### Request

```
GET /students?fees=45000
```

Returns students whose fees are greater than the provided amount.

---

## Add Student

### Request

```
POST /students
```

Example Request Body:

```json
{
  "id": 11,
  "name": "Alex",
  "age": 21,
  "course": "B.TECH",
  "fees": 50000
}
```

Response:

```
Student added successfully
```

If student ID already exists:

```
409 Conflict
```

---

## Update Student

### Request

```
PUT /students
```

Updates existing student information.

---

## Delete Student

### Request

```
DELETE /students?Id=1
```

Deletes a student record using student ID.

---

# 🔐 Header Authentication

The API uses custom header-based authentication.

Every request requires:

```
Header Name:
SecretKey

Value:
12345
```

If the header is missing or the key is incorrect:

Response:

```
401 Unauthorized
```

---

# ⚙️ Middleware Pipeline

The application contains multiple custom middleware components.

## Request Logging Middleware

Tracks:

* Request time
* HTTP method
* Request path
* Response status code
* Request execution time

---

## Maintenance Mode Middleware

The application can simulate maintenance mode.

When enabled:

Response:

```
503 Service Unavailable
Website is under maintenance
```

---

## Authentication Middleware

Validates the `SecretKey` header before allowing access to student endpoints.

---

# ▶️ How To Run

Clone the repository:

```bash
git clone https://github.com/mdanasalam24/Student_Management_API.git
```

Navigate to project directory:

```bash
cd Student_Management_API
```

Run the application:

```bash
dotnet run
```

---

# 🔮 Future Improvements

* Replace in-memory repository with a database
* Add proper dependency injection for repository layer
* Add DTO implementation
* Add Swagger API documentation
* Add automated testing

---

# 👨‍💻 Author

**MD Anas**

GitHub:
https://github.com/mdanasalam24
