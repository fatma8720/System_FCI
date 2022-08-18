using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;using static System.Console;
namespace System_FCI
{
    public interface SeaechDelete<T>
    {
        List<T> Search(string name);
        void Delete(string name, string department);
    }
    class MyCompareClass : IComparer<KeyValuePair<int, double>>
    {
        public int Compare(KeyValuePair<int, double> x, KeyValuePair<int, double> y)
        {
            if (x.Value > y.Value)
            {
                return -1;
            }
            else if (x.Value < y.Value)
                return 1;
            else
            {
                return 0;
            }
        }
    }
    static class helper
    {

        public static bool CheckDepartment(this string department)
        {
            return
                (
                    department.ToUpper() == "CS" ||
                    department.ToUpper() == "IS" ||
                    department.ToUpper() == "IT" ||
                    department.ToUpper() == "BIO" ||
                    department.ToUpper() == "SE"

                );
        }
        public static bool CheckGender(this string gen)
        {
            return
                (
                   gen.ToUpper() == "FEMALE" ||
                   gen.ToUpper() == "MALE"

                );
        }
        public static bool CheckType(this string Type)
        {
            return
                (
                   Type.ToUpper() == "DOCTOR" ||
                   Type.ToUpper() == "ASSISTANT"

                );
        }
        public static List<Student> DepMembers(this List<Student> StudentList, string dep)
        {
            List<Student> StudentListdep = new List<Student>();

            foreach (var item in StudentList )
            {
                if (item != null&&item.Name!=null)
                {
                    if (item.StudentDEP.ToString() == dep)
                        StudentListdep.Add(item);
                }
            }
            return StudentListdep;
        }
        public static void fristrankDepMember(this List<Student> StudentList, string dep)
        {
            List<Student> StudentListdepa = new List<Student>();
            StudentListdepa=StudentList.DepMembers(dep);
            if (StudentListdepa.Count != 0)
            {
                StudentListdepa.Sort();
                // return StudentListdepa.FirstOrDefault();
                Console.WriteLine(StudentListdepa.FirstOrDefault());
            }
            else
                Console.WriteLine("\n\nDepartment is empty\n\n");

        }
        public static List<Instructor> FilterInstructorInGenderBase(this List<Instructor> InstructorList, string gender)
        {
              List<Instructor> InstructorListGen  = new List<Instructor>();

            foreach (var item in InstructorList)
            {
                if (item != null && item.Name != null)
                {
                    if (item.Gender.ToString() == gender)
                        InstructorListGen.Add(item);
                }
            }
            return InstructorListGen;
        }
        public static void FilterWorkerSalaryBased(this List<Worker> Workerlist)
        {
            List<Worker> WorkerListSAL = new List<Worker>();

            Dictionary<int, double> workerdic = new Dictionary<int, double>();

            foreach (var item in Workerlist)
            {
               int ID = item.WorkerID;

                if (!workerdic.ContainsKey(ID))
                {
                    workerdic.Add(ID, item.WorkerSalary);
                }
            }

            var tempList = workerdic.ToList();
            tempList.Sort(new MyCompareClass());

            foreach (var item in tempList.GetRange(0, 3))
            {
                Console.WriteLine(item);
            }
        }

    }

    class Program
    {
        #region Display Fuctions
        public static void Minu()
        {

            WriteLine("\t Welcome \t");
            WriteLine();
            WriteLine("\t\t Diaplay Data  :\t\t\t 1 ");
            WriteLine("\t\t Clear Data  :\t\t\t\t 2 ");
            WriteLine("\t\t Add Person  :\t\t\t\t 3 ");
            WriteLine("\t\t Search About Person  :\t\t\t 4");
            WriteLine("\t\t Delete Person :\t\t\t 5 ");
            WriteLine("\t\t Sorting :\t\t\t\t 6 ");
            WriteLine("\t\t DO More Functionality  :\t\t 7 ");
            WriteLine("\t\t Close Program  :\t\t\t-1 ");
            WriteLine("\n\n\t\tPress the Number \n\n");
        }   // Choices for main fuctions int the project
        public static void DOMinu(string what)
        {
            WriteLine("\n" + what + "\tStudents:\t\t1");
            WriteLine(what + "\tInstructors:\t\t2 ");
            WriteLine(what + "\tWorkers:\t\t3 ");
            WriteLine("\nBack:\t\t\t\t\t4 ");
            WriteLine("\t\n\n Press the Number \t\n");

        }  // some general method -- for whole list
        public static void Mainiplation(string what)
        {
            WriteLine("\n" + what + "\t\tStudents:\t\t1");
            WriteLine(what + "\t\tInstructors:\t\t2 ");
            WriteLine(what + "\t\tWorkers:\t\t3 ");
            WriteLine("\nBack:\t\t\t\t\t4 ");
            WriteLine("\t\n\n Press the Number \t\n");

        } //Add -Seaech-Delete
        public static void MoreFunctionality()
        {
            WriteLine("\n Diplay students in Spicific Department : \t\t\t\t 1 ");
            WriteLine(" Display The student at the first rank in each department : \t\t 2");
            WriteLine(" Display Instructors with Male gender : \t\t\t\t 3");
            WriteLine(" Display the largest three worker in salary : \t\t\t\t 4");
            WriteLine("\n Back:\t\t\t\t\t\t\t\t\t 5");
            WriteLine("\t\n Press the Number \t\n");

        } // for Display Main Filters
        public static void DepMinu(string w)
        {
            WriteLine(w+" in CS  :        1 ");
            WriteLine(w+" in IT  :        2 ");
            WriteLine(w+" in IS  :        3 ");
            WriteLine(w+" in BIO :        4 ");
            WriteLine(w+" in SE  :        5 ");
            WriteLine("\nBack :  6 ");
            WriteLine("\t\n Press the Number \t\n");

        } //for filter departments choices 
        public static void GenMinu()
        {
            WriteLine("Display gender Male :    1");
            WriteLine("Display gender Female :  2");
            WriteLine("\nBack :                   3");
            WriteLine("\t\n Press the Number \t\n");

        }  // for filter gender choices
        #endregion

        static void Main(string[] args)
        {

            #region try
            //List<Person> College = new List<Person> ()
            //{
            //      new Student() { StudentID = 1, Name = "Zahra", Age = 19, GPA = 4 , Gender=Gender.FEMALE},
            //      new Student() { StudentID = 2, Name = "Ali", Age = 20, GPA = 3.5f , Gender=Gender.MALE},
            //      new Student() { StudentID = 3, Name = "Alaa", Age = 21, GPA = 2 },

            //      new Instructor() { InstructorID = 1, Name = "Ola", Age = 25, Salary = 5000, Gender=Gender.FEMALE,InstructorType=Type.Assistant,InstructorDepartment=DEP.CS},
            //      new Instructor() { InstructorID = 2, Name = "Hassan", Age = 26, Salary = 6000 ,Gender=Gender.MALE,InstructorType=Type.Assistant,InstructorDepartment=DEP.IS},
            //      new Instructor() { InstructorID = 3, Name = "Ahmed", Age = 45, Salary = 9000,Gender=Gender.MALE,InstructorType=Type.Doctor ,InstructorDepartment=DEP.IT},

            //      new Worker() { WorkerID = 1, Name = "Soad", Age = 39, WorkerSalary = 3000 , Gender=Gender.FEMALE},
            //      new Worker() { WorkerID = 2, Name = "Mostafa", Age = 48, WorkerSalary = 3700 , Gender=Gender.MALE},
            //      new Worker() { WorkerID = 3, Name = "Saad", Age = 50, WorkerSalary = 4000 , Gender=Gender.MALE}

            //};    
            //College.Sort();
            //foreach (var item in College)
            //{
            //    if(item is Student) // if Instructor --- if Worker 
            //    Console.WriteLine(item.ToString());
            //}
            #endregion

            #region Obiects used

            Student student1 = new Student();
            Instructor instructor1= new Instructor();
            Worker worker1 = new Worker();

            List<Student> students = student1.GetStudentsList();
            List<Instructor> instructors = instructor1.GetInstructorList();
            List<Worker> workers = worker1.GetWorkersList();

            #endregion

            while (true) // for run program all time
            {
                WriteLine();
                Minu();
                WriteLine();
                int Choice = int.Parse(ReadLine());
                if (Choice == 1)
                {
                    while (true)
                    {
                        DOMinu("Display All");
                        WriteLine("\n\n");
                        int DisplayChoice = int.Parse(ReadLine());
                        if (DisplayChoice == 1)
                        {
                            WriteLine("\n\n");
                            student1.ShowStudetsInList(students);
                            WriteLine("\n\n");
                        }
                        else if (DisplayChoice == 2)
                        {
                            WriteLine("\n\n");

                            instructor1.ShowInstructorsInList(instructors);
                            WriteLine("\n\n");

                        }
                        else if (DisplayChoice == 3)
                        {
                            WriteLine("\n\n");
                            worker1.ShowWorkersInList(workers);
                            WriteLine("\n\n");

                        }
                        else if (DisplayChoice == 4)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("\t Error Enter Number from formerly minu \t");
                        }
                    }
                } // Display all data of different persons
                else if (Choice == 2)
                {
                   
                    while (true)
                    {
                        DOMinu("Clear All");
                        WriteLine("\n\n");
                        int ClearChoice = int.Parse(ReadLine());
                        if (ClearChoice == 1)
                        {
                            student1.ClearData();
                        }
                        else if (ClearChoice == 2)
                        {
                            instructor1.ClearData();
                        }
                        else if (ClearChoice == 3)
                        {
                            worker1.ClearData();
                        }
                        else if (ClearChoice == 4)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("\t Error Enter Number from formerly minu \t");
                        }
                    }
                } // clear all data different persons
                else if (Choice == 3)
                {
                    while (true)
                    {
                        Mainiplation("Add");
                        int AddChoice = int.Parse(ReadLine());
                        if (AddChoice == 1)
                        {
                            WriteLine("\n\t what is the number of students \t\n");
                            int NumOfStudent = int.Parse(ReadLine());
                            for (int i = 1; i <= NumOfStudent; i++)
                            {
                                WriteLine("ID Of Student : " + i);
                                int ID = int.Parse(ReadLine());
                                WriteLine("Name Of : Student" + i);
                                string Name = ReadLine();
                            DeptGEN:
                                WriteLine("DEP Of : Student " + i + "\t from : CS IS, IT, BIO, SE");
                                string Department = ReadLine();
                                WriteLine(" Gender Of: Student" + i);
                                string Gen = ReadLine();
                                if (Department.CheckDepartment() && Gen.CheckGender())
                                {

                                    WriteLine("Age  Of : Student" + i);
                                    int Age = int.Parse(ReadLine());
                                    WriteLine("GPA Of : Student" + i);
                                    float GPA = float.Parse(ReadLine());
                                    Student student = new Student() { StudentID = ID, Name = Name, Age = Age, GPA = GPA, Gender = (Gender)Enum.Parse(typeof(Gender), Gen, true), StudentDEP = (DEP)Enum.Parse(typeof(DEP), Department, true) };
                                    students.Add(student);
                                }
                                else
                                {
                                    WriteLine("UnCorrect Department or Gender!");
                                    goto DeptGEN;
                                }
                            }
                            WriteLine("\n \t\t Student Have been Added \t\t \n ");

                        }
                        else if (AddChoice == 2)
                        {
                            WriteLine("\n\t what is the number of Instructors \t\n");
                            int NumOfInstructor = int.Parse(ReadLine());
                            for (int i = 1; i <= NumOfInstructor; i++)
                            {
                                WriteLine("ID Of" + i + " : Instructor");
                                int ID = int.Parse(ReadLine());
                                WriteLine("Name Of" + i + " : Instructor");
                                string Name = ReadLine();
                            DeptGEN:
                                WriteLine("DEP Of" + i + " : Instructor \t from : CS IS, IT, BIO, SE");
                                string Department = ReadLine();
                                WriteLine(" Gender Of" + i + " : Instructor");
                                string Gen = ReadLine();
                                if (Department.CheckDepartment() && Gen.CheckGender())
                                {

                                    WriteLine("Age  Of" + i + " : Instructor");
                                    int Age = int.Parse(ReadLine());
                                    WriteLine("Salary Of" + i + " : Instructor");
                                    float Salary = float.Parse(ReadLine());
                                    Instructor instructor = new Instructor() { InstructorID = ID, Name = Name, Age = Age, Salary = Salary, Gender = (Gender)Enum.Parse(typeof(Gender), Gen, true), InstructorDepartment = (DEP)Enum.Parse(typeof(DEP), Department, true) };
                                    instructors.Add(instructor);
                                }
                                else
                                {
                                    WriteLine("UnCorrect Department or Gender!");
                                    goto DeptGEN;
                                }
                            }
                            WriteLine("\n \t\t Instructor Have been Added \t\t \n ");
                        }
                        else if (AddChoice == 3)
                        {
                            WriteLine("\n\t what is the number of Workers \t\n");
                            int NumOfWorkers = int.Parse(ReadLine());
                            for (int i = 1; i <= NumOfWorkers; i++)
                            {
                                WriteLine("ID Of" + i + " : Workers");
                                int ID = int.Parse(ReadLine());
                                WriteLine("Name Of" + i + " : Workers");
                                string Name = ReadLine();
                                WriteLine(" Gender Of" + i + " :Workers");
                                string Gen = ReadLine();
                            GEN:
                                if (Gen.CheckGender())
                                {

                                    WriteLine("Age  Of" + i + " : Workers");
                                    int Age = int.Parse(ReadLine());
                                    WriteLine("Salary Of" + i + " : Workers");
                                    float Salary = float.Parse(ReadLine());
                                    Worker worker = new Worker() { WorkerID = ID, Name = Name, Age = Age, WorkerSalary = Salary, Gender = (Gender)Enum.Parse(typeof(Gender), Gen, true) };
                                    workers.Add(worker);
                                }
                                else
                                {
                                    WriteLine("UnCorrect Gender!");
                                    goto GEN;
                                }
                            }
                            WriteLine("\n \t\t Worker Have been Added \t\t \n ");

                        }
                        else if (AddChoice == 4)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("\t Error Enter Number from formerly minu \t");
                        }

                    }
                } // Add person data from different types
                else if (Choice == 4)
                {
                    while (true)
                    {
                        Mainiplation("Search");
                        int SearchChoice = int.Parse(ReadLine());
                        if (SearchChoice == 1)
                        {
                            WriteLine("Enter Student Name  : ");
                            string studentName = ReadLine();
                            List<Student> Matches = student1.Search(studentName);
                            if (Matches.Count == 0)
                            {
                                WriteLine("\n\n -Not Found-\n\n");
                            }
                            else
                            {
                                student1.ShowStudetsInList(Matches);
                            }
                            
                        }
                        else if (SearchChoice == 2)
                        {
                            WriteLine("Enter Instructor Name  : ");
                            string InstructorName = ReadLine();
                            List<Instructor> Matches = instructor1.Search(InstructorName);
                            if (Matches.Count == 0)
                            {
                                WriteLine("\n\n -Not Found-\n\n");
                            }
                            instructor1.ShowInstructorsInList(Matches);
                        }
                        else if (SearchChoice == 3)
                        {
                            WriteLine("Enter Worker Name  : ");
                            string TechnicianName = ReadLine();
                            List<Worker> Matches = worker1.Search(TechnicianName);
                            if (Matches.Count == 0)
                            {
                                WriteLine("\n\n -Not Found-\n\n");
                            }
                            worker1.ShowWorkersInList(Matches);
                        }
                        else if (SearchChoice == 4)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("\t Error Enter Number from formerly minu \t");
                        }
                    }
                } // search about person
                else if (Choice == 5)
                {
                    while (true)
                    {
                        Mainiplation("Delete");
                        int DeleteChoice = int.Parse(ReadLine());
                        if (DeleteChoice == 1)
                        {
                            Write(" Name Of Student  : ");
                            string StudentName = ReadLine();
                            Write(" Department : ");
                            string StudentDepartment = ReadLine();
                            student1.Delete(StudentName, StudentDepartment);
                        }
                        else if (DeleteChoice == 2)
                        {
                            Write("Name Of Instructor : ");
                            string instructortName = ReadLine();
                            Write("Department : ");
                            string instructorDepartment = ReadLine();
                            instructor1.Delete(instructortName, instructorDepartment);
                        }
                        else if (DeleteChoice == 3)
                        {
                            Write("Name Of Worker  : ");
                            string workerName = ReadLine();
                            worker1.Delete(workerName);
                        }
                        else if (DeleteChoice == 4)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("\t Error Enter Number from formerly minu \t");
                        }
                    }
                } // Delete person data from different types
                else if (Choice == 6)
                {
                    while (true)
                    {
                        DOMinu("Sort All");
                        int SortChoice = int.Parse(ReadLine());
                        if (SortChoice == 1)
                        {
                            students.Sort();
                            //student1.ShowStudetsInList(student1.GetStudentsList());
                        }
                        else if (SortChoice == 2)
                        {
                            instructors.Sort();
                            //instructor1.ShowInstructorsInList(instructor1.GetInstructorList());
                        }
                        else if (SortChoice == 3)
                        {
                            workers.Sort();
                            //  worker1.ShowWorkersInList(worker1.GetWorkersList());
                        }
                        else if (SortChoice == 4)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("\t Error Enter Number from formerly minu \t");
                        }
                    }
                } // sorting -- student based gpa -- instructor based name -- worker based salary 
                else if (Choice == 7)    
                {
                    while (true)
                    {
                        MoreFunctionality();
                        int FuncChoice = int.Parse(ReadLine());
                        if (FuncChoice == 1)
                        {
                            while (true)
                            {
                                DepMinu("Display All");
                                int DepChoice = int.Parse(ReadLine());
                                if (DepChoice == 1)
                                {
                                    foreach (var student in student1.GetStudentsList().DepMembers("CS"))
                                    {
                                        WriteLine(student.ToString());
                                    }
                                }
                                else if (DepChoice == 2)
                                {
                                    foreach (var student in student1.GetStudentsList().DepMembers("IT"))
                                    {
                                        WriteLine(student.ToString());
                                    }
                                }
                                else if (DepChoice == 3)
                                {
                                    foreach (var student in student1.GetStudentsList().DepMembers("IS"))
                                    {
                                        WriteLine(student.ToString());
                                    }
                                }
                                else if (DepChoice == 4)
                                {
                                    foreach (var student in student1.GetStudentsList().DepMembers("BIO"))
                                    {
                                        WriteLine(student.ToString());
                                    }
                                }
                                else if (DepChoice == 5)
                                {
                                    foreach (var student in student1.GetStudentsList().DepMembers("SE"))
                                    {
                                        WriteLine(student.ToString());
                                    }
                                }
                                else if (DepChoice == 6)
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("\t Error Enter Number from formerly minu \t");
                                }
                            }
                        }       //Sorting any type of person Using IComprable interface
                        else if (FuncChoice == 2)
                        {
                            while (true)
                            {
                                DepMinu("Student at the first rank ");
                                int DepChoice = int.Parse(ReadLine());
                                if (DepChoice == 1)
                                {
                                   student1.GetStudentsList().fristrankDepMember("CS");

                                }
                                else if (DepChoice == 2)
                                {
                                   student1.GetStudentsList().fristrankDepMember("IT");

                                }
                                else if (DepChoice == 3)
                                {
                                  student1.GetStudentsList().fristrankDepMember("IS");

                                }
                                else if (DepChoice == 4)
                                {
                                  student1.GetStudentsList().fristrankDepMember("BIO");

                                }
                                else if (DepChoice == 5)
                                {
                                    student1.GetStudentsList().fristrankDepMember("SE");

                                }
                                else if (DepChoice == 6)
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("\t Error Enter Number from formerly minu \t");
                                }
                            }
                        }  //Display All Student in specific Departments
                        else if (FuncChoice == 3)
                        {

                            while (true)
                            {
                                GenMinu();
                                int GenChoice = int.Parse(ReadLine());
                                if (GenChoice == 1)
                                {
                                    foreach (var instructor in instructor1.GetInstructorList().FilterInstructorInGenderBase("MALE"))
                                    {
                                        WriteLine(instructor.ToString());
                                    }
                                }
                                else if (GenChoice == 2)
                                {
                                    foreach (var instructor in instructor1.GetInstructorList().FilterInstructorInGenderBase("FEMALE"))
                                    {
                                        WriteLine(instructor.ToString());
                                    }
                                }
                                else if (GenChoice == 3)
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("\t Error Enter Number from formerly minu \t");
                                }
                            }
                        }  //Display The student at the first rank in each department
                        else if (FuncChoice == 4)
                        {
                            worker1.GetWorkersList().FilterWorkerSalaryBased();
                        }  //Display Instructors with male gender
                        else if (FuncChoice == 5)
                        {
                            break;
                        }  //Display the largest three worker in salary
                        else
                        {
                            WriteLine("\t Error Enter Number from formerly minu \t");
                        } //Error Message for wrong choice
                    }
                }    //  the fuctionallity 
                else if (Choice == -1)
                {
                    break;
                }  // to End the program 

            }  
          Console.ReadKey();
        }
    }
}

