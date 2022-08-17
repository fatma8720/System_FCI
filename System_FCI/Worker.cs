using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace System_FCI
{
   public class Worker : Person , SeaechDelete<Worker>, IComparable<Worker>
    {
        //Atrributes
        List<Worker> Workers;
        public Worker()
        {
            Workers = Faculty.Workers;
        }
        static Worker() { }
        public int WorkerID { get; set; }
        public double WorkerSalary { get; set; }
        public override string ToString()
        {
            return ("{" + Name + "\t\t" + Age + "  Years old" + "\t\t" + WorkerSalary +" EGP"+ "\t\t }");
        } // return data of one worker
        public List<Worker> GetWorkersList()
        {
            return Workers;
        } // return list of workers 
        public List<Worker> Search(string name)
        {
            List<Worker> WantedWorker = new List<Worker>();
            foreach (var item in Workers)
            {
                if (item.Name == name) // if Instructor --- if Worker 
                    WantedWorker.Add(item);
            }
            return WantedWorker;
        } // search about worker 
        public void Delete(string name, string Department=" ")
        {
            List<Worker> res = Search(name);
            if (res.Count == 0) WriteLine("\n\t NOT Found \t\n");
            else
            {
                foreach (var item in Workers)
                {
                    if (item.Name == name)
                        Workers.Remove(item);
                }
                WriteLine("\n \t\t Worker with this data Have been Deleted \t\t \n ");

            }
        } // delete worker
        public void ClearData()
        {
            Workers.Clear();
        } // remove all worker
        public void ShowWorkersInList(List<Worker> workers)
        {
            if (Workers == null)
                return;
            foreach (var worker in Workers)
            {
                WriteLine(worker.ToString());
            }
        } // print all workers 
        public int CompareTo(Worker other)
        {
            if (this != null && other != null)
            {
                return (Age.CompareTo(other.Age));
            }
            else return 0;
        } // compare for sort with IComparable

    }
}
