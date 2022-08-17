using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_FCI
{
    public enum Gender
    {
        MALE,
        FEMALE
    }
   public abstract class  Person : IComparable<Person>
    { 
        //Atrributes
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name :\t {Name} ");
        } //print Data 
        public int CompareTo(Person other)
        {
            return string.CompareOrdinal(Name, other.Name);
        } // compare for sort with IComparable
    }
}
