using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
static class ExtentionSTU
{

}
namespace System_FCI
{
    public enum DEP
    {
        CS,
        IS,
        IT,
        BIO,
        SE
    }

   public class Student : Person ,SeaechDelete<Student>, IComparable<Student>
    {
        List<Student> Students;
        public Student()
        {
            Students = Faculty.Students;
        } // intilize list of Students

          //Atrributes
        public int StudentID { get; set; }
        private float gPA;
        public float GPA
        {
            get
            {
                return this.gPA;
            }
            set
            {
                if (value > 4)
                {
                    this.gPA = 4;
                }
                else
                {
                    this.gPA = value;
                }
            }
        }
        public DEP StudentDEP { get; set; }


        //public Student(List<Student> students, int studentID,float gPA, DEP studentDEP)
        //{
        //    Students = students;
        //    StudentID = studentID;
        //    GPA = gPA;
        //    StudentDEP = studentDEP;
        //    Students = Faculty.Students;
        //}
        public override string ToString()
        {
            if (this != null)
                return ("{" + Name + "\t\t" + Age + " Years old" + "\t\t" + GPA + " G" + "\t\t" + StudentDEP + "}");
            else
                return ("Empty Data Null Object");
        } // return data of one Student
        public List<Student> GetStudentsList()
        {
            return Students;
        } // return list of Students
        public List<Student> Search(string name)
        {
            List<Student> WantedStudent = new List<Student>();
            foreach (var item in Students)
            {
                if (item.Name == name) // if Instructor --- if Worker 
                {
                    WantedStudent.Add(item);
                }
            }
            return WantedStudent;
        } // search about Student
        public void Delete(string name, string Department)
        {
            List<Student> res = Search(name);
            if (res.Count == 0) WriteLine("\n\t NOT Found \t\n");
            else
            {
                for(int i = 0 ; i< res.Count; i++)
                {
                    if (res[i].StudentDEP.ToString() == Department)
                    {
                        Students.Remove(res[i]);
                    }
                }
                    WriteLine("\n \t\t Student with this data Have been Deleted \t\t \n ");
            }
        } // delete Student
        public void ClearData()
        {
            Students.Clear();
        } // remove all Students
        public void ShowStudetsInList(List<Student> students)
        {
            if (students == null)
                return;
            foreach (var student in students)
            {
                WriteLine(student.ToString());
            }
        } //print all Students
        public int CompareTo(Student other)
        {
            if (this != null && other != null)
            {
                return (other.GPA.CompareTo(GPA));
            }
            else return 0;
        } // compare for sort with IComparable

    }
}
