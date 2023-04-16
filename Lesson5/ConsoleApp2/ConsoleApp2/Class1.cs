using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //затупила, классы нужно было создать еще в прошлой программе...
    public class Class1
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateOfLastChange { get; set; }


        public Class1(string name1, string type1, DateTime date1) 
        { 
            Name = name1;
            Type = type1;
            DateOfLastChange = date1;
        }
    }
}
