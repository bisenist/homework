using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public abstract class Doctor : IShowInfo
    {
        public string DoctorName { get; set; }
        public int DoctorAge { get; set; }
        public int Experience { get; set; }

        public Doctor(string name, int age, int experience) //конструктор
        {
            DoctorName = name;
            DoctorAge = age;
            Experience = experience;
        }

        public abstract void ShowInfo ();
        
       /* 
        public abstract void MedicalExamination();

        public abstract bool Cure();
       
        я сделала эти два метода, но почему-то в дочерних классах программа ноет, что методы не реализованы, хотя они есть!!
        взорвала и закомментировала их
        */
    }
}
