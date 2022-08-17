using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace System_FCI
{
    public enum Type
    {
        Doctor,
        Assistant
    }
   public class Instructor : Person, SeaechDelete<Instructor>,IComparable<Instructor>
    {
        List<Instructor> Instructors;
        public Instructor()
        {
            Instructors = Faculty.Instructors;
        } // intilize list of instructor
          //Atrributes
        public int InstructorID { get; set; }
        public Type InstructorType { get; set; }
        public DEP InstructorDepartment { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return ("{" + Name + "\t\t" + Age + " Years old" + "\t\t" + Salary+" EGP" + "\t\t" + InstructorType+ "\t\t" + InstructorDepartment+ "\t\t }");
        } // return data of one instructor
        public List<Instructor> GetInstructorList()
        {
            return Instructors;
        } // return list of instructors
        public List<Instructor> Search(string name)
        {
            List<Instructor> WantedInstructors = new List<Instructor>();
            foreach (var item in Instructors)
            {
                if (item.Name == name) // if Instructor --- if Worker 
                    WantedInstructors.Add(item);
            }
            return WantedInstructors;
        } // search about 
        public void Delete(string name, string Department)
        {
            List<Instructor> res = Search(name);
            if (res.Count == 0) WriteLine("\n\t NOT Found \t\n");
            else
            {
                foreach (var item in Instructors)
                {
                    if (item.Name == name && item.InstructorDepartment.ToString() == Department)
                        Instructors.Remove(item);
                }
                WriteLine("\n \t\t Instructor with this data Have been Deleted \t\t \n ");

            }
        } // delete
        public void ClearData()
        {
            Instructors.Clear();
        } // remove all 
        public void ShowInstructorsInList(List<Instructor> instructors)
        {
            if (Instructors == null)
                return;
            foreach (var instructor in Instructors)
            {
                WriteLine(instructor.ToString());
            }
        } // print all 
        public int CompareTo(Instructor other)
        {
            return string.CompareOrdinal(Name, other.Name);
        } // compare for sort with IComparable

    }
}
