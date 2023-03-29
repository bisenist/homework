using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class Patient : IShowInfo
    {
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public bool Status { get; set; }
        
        public bool HeartSymptom { get; set; } 

        public bool LungsSymptom { get; set; } 

        public bool GastroSymptom { get; set; } 

        public Patient(string name, int age) //конструктор
        {
            PatientName = name;
            PatientAge = age;
        }

        public void ShowInfo() => Console.WriteLine($"Пациент. ФИО: {PatientName}. Возраст: {PatientAge}."
                      +" Состояние пациента " + PatientName + ": " + (Status? "болен. Требуется осмотр специалистов" : "здоров"));

        public bool IsIll () //метод, определяющий состояние здоровья. получился глупым, придется каждый раз его вызывать, чтобы понять, что с пациентом
        {
            if (HeartSymptom || LungsSymptom || GastroSymptom)
            {
                Status = true;
            }
            else
            {
                Status = false;
            }
            return Status;
        }
    }
}
