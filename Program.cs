using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Microsoft.VisualBasic;
using Student_Management_API.Models;
using Student_Management_API.Repository;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async(context, next) => {
  
    context.Response.ContentType = "text/html";
    DateTime now = DateAndTime.Now;
    Stopwatch st = new Stopwatch();
    Console.WriteLine($"---------Request Started---------: <br>");
    Console.WriteLine($"Time : {now} <br>");
    Console.WriteLine($"Request Method: {context.Request.Method}<br>");
    Console.WriteLine($"Request Path: {context.Request.Path}<br>");

    if (context.Request.Path.StartsWithSegments("/students"))
    {
        st.Start();
        await next(context);
        Console.WriteLine($"Status code of the request is {context.Response.StatusCode}<br>");
        st.Stop();
        Console.WriteLine($" time to compelete task: {st.ElapsedMilliseconds}");
        Console.WriteLine($"---------Request Ended---------:<br>");
    }
    else
    {
       context.Response.StatusCode = 400;
        Console.WriteLine($"Invalid Route Accessed");
        Console.WriteLine($"Status code of the request is {context.Response.StatusCode}<br>");
        Console.WriteLine($"---------Request Ended---------:<br>");
    }
});

app.Use(async(HttpContext context, RequestDelegate next) =>
    {
        bool Maintainance_Mode = true;
            if (Maintainance_Mode is true)
            {
                context.Response.StatusCode = 503;
                await context.Response.WriteAsync($" service Unavilabe \n Website is under maintenance");
                Console.WriteLine("service Unavilabe");
            }
            else
            {
                await next(context);
            }

});
app.Use(async(HttpContext context, RequestDelegate next) =>
{
  
    if (context.Request.Headers.Keys.Contains("SecretKey"))
    {
        
        var secretkey = 12345;
        var secret = Convert.ToInt32(context.Request.Headers["SecretKey"]);
        if (secretkey == secret)
        {
            await next(context);
        }
        else
        {
            context.Response.StatusCode = 401;
            Console.WriteLine($"You are Unauthorised");
            await context.Response.WriteAsync($"You are Unauthorised");
          
        }
    }
    else
    {
        context.Response.StatusCode = 401;
        Console.WriteLine($"Header does'nt contain Secret key");
        await context.Response.WriteAsync($"Header does'nt contain Secret key");
    }
    
});



app.Run(async(HttpContext context) =>
{
    
    if (context.Request.Path.StartsWithSegments("/students"))
    {
        if (context.Request.Method == "GET")
        {
            
            if (context.Request.Query.ContainsKey("id"))
            {
               
                var id = Convert.ToInt32(context.Request.Query["id"]);

                var students = StudentRepository.GetStudentbyId(id);
                if (students is not null)
                {
                    await context.Response.WriteAsync($"Id= {students.Id}, Name: {students.Name}, Age: {students.Age}, Course: {students.Course}, Fees: {students.Fees}<br>");
                    
                }
                else
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync("Student not found ");
                   
                }
            }
            else if (context.Request.Query.ContainsKey("Course"))
            {
                var course = context.Request.Query["Course"];

                var students = StudentRepository.GetStudentbyCourse(course);

                foreach (var student in students)
                {
                    await context.Response.WriteAsync($"Id= {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}, Fees: {student.Fees}<br>");
                }
            }

            else if (context.Request.Query.ContainsKey("fees"))
            {
                var fees = Convert.ToDouble(context.Request.Query["fees"]);
                var result3 = StudentRepository.GetStudentbyfees(fees);
                foreach (var student in result3)
                {
                    await context.Response.WriteAsync($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}, fees: {student.Fees}<br> ");
                }

            }
            else
            {
                await context.Response.WriteAsync($"The List of the student is : <br>");
                    var student = StudentRepository.GetAllStudent();
                    foreach (var s in student)
                    {
                        await context.Response.WriteAsync($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}, Course: {s.Course}, fees: {s.Fees} <br>");
                    }
                
            }
        }
        else if (context.Request.Method == "POST")
        {
            var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();
            var student = JsonSerializer.Deserialize<Student>(body);

            var result = StudentRepository.AddStudent(student);

            if (result)
            {
                context.Response.StatusCode = 201;
                await context.Response.WriteAsync("Student added successfully");
            }
            else
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync("Id is duplicate, please add Non exitsting Id");
            }

        }
        else if (context.Request.Method == "PUT")
        {
            var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();
            var student = JsonSerializer.Deserialize<Student>(body);
           var result = StudentRepository.UpdateStudent(student);
            if (result )
            {
                await context.Response.WriteAsync("User Updated successfully");
            }
            else
            {
                await context.Response.WriteAsync("User Not Found");
            }

        }
        else if (context.Request.Method == "DELETE")
        {
            var idd = Convert.ToInt32(context.Request.Query["Id"]);

            var result = StudentRepository.DeleteStudent(idd);
            if (result)
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Student Deleted Succesfully");

            }
            else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Student does not Exist");
            }
        }

        else if (context.Request.Method == "PATCH")
        {
            context.Response.StatusCode = 405;
            await context.Response.WriteAsync("405 Method Not Allowed");
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("404 Page Not Found");
        }
    }
    else
    {
      
        context.Response.StatusCode = 404;
       await context.Response.WriteAsync($"Invalid Route Accessed ");
    }


});

app.Run();





