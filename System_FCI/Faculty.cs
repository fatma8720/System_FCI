using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_FCI
{
    class Faculty
    {
       public static List<Student> Students = new List<Student>() 
        {
          new Student() { StudentID = 1, Name = "Zahra", Age = 19, GPA = 4 , Gender=Gender.FEMALE,StudentDEP=DEP.CS},
          new Student() { StudentID = 2, Name = "Ali", Age = 20, GPA = 3.5f , Gender=Gender.MALE,StudentDEP=DEP.IS},
          new Student() { StudentID = 3, Name = "Alaa", Age = 21, GPA = 1.5f,StudentDEP=DEP.CS },
          new Student() { StudentID = 4, Name = "eman", Age = 22, GPA = 2.7f , Gender=Gender.FEMALE,StudentDEP=DEP.BIO},
          new Student() { StudentID = 5, Name = "mona", Age = 29, GPA = 3.5f , Gender=Gender.MALE,StudentDEP=DEP.SE}
        };
        public static List<Instructor> Instructors = new List<Instructor>() 
        {
          new Instructor() { InstructorID = 1, Name = "Ola", Age = 25, Salary = 5000, Gender=Gender.FEMALE,InstructorType=Type.Assistant},
          new Instructor() { InstructorID = 2, Name = "Hassan", Age = 26, Salary = 6000 ,Gender=Gender.MALE,InstructorType=Type.Assistant},
          new Instructor() { InstructorID = 3, Name = "Ahmed", Age = 45, Salary = 9000,Gender=Gender.MALE,InstructorType=Type.Doctor }
        };
        public static List<Worker> Workers = new List<Worker>() 
        {
          new Worker() { WorkerID = 1, Name = "Soad", Age = 50, WorkerSalary = 5000 , Gender=Gender.FEMALE},
          new Worker() { WorkerID = 3, Name = "Saad", Age = 20, WorkerSalary = 2500 , Gender=Gender.MALE},
          new Worker() { WorkerID = 4, Name = "Saeed", Age = 50, WorkerSalary = 9000 , Gender=Gender.FEMALE},
          new Worker() { WorkerID = 6, Name = "Aliaa", Age = 20, WorkerSalary = 7000 , Gender=Gender.MALE},
          new Worker() { WorkerID = 5, Name = "Mohamed", Age = 38, WorkerSalary = 4500 , Gender=Gender.MALE},
          new Worker() { WorkerID = 2, Name = "Mostafa", Age = 38, WorkerSalary = 3700 , Gender=Gender.MALE}

        };

    }
}
