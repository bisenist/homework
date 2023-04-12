using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class Cardiologist : Doctor
    {
        public string Speciality { get; } = "Кардиолог";

        public Cardiologist(string name, int age, int experience) : base(name, age, experience) //конструктор
        {
        }

        public override void ShowInfo() => Console.WriteLine($"Доктор. ФИО: {DoctorName}  Возраст: {DoctorAge} "
                                                            +$"Специальность: {Speciality}  Стаж: {Experience}");

        public bool Cure(Patient patient) 
        {
            if (patient.HeartSymptom)
            {
                patient.HeartSymptom = false;
                Console.WriteLine($"Пациент {patient.PatientName} прошел лечение кардиолога {DoctorName}. Проблемы с сердцем больше не беспокоят");
            }
            else
            {
                Console.WriteLine($"Пациенту {patient.PatientName} лечение кардиолога не требуется. Лечение не проведено");
            }
            patient.IsIll(); //для обновления состояния пациента
            return patient.HeartSymptom;
        }

        public void MedicalExamination(Patient patient) //осмотр пациента специалистом
        {
            if (patient.HeartSymptom)
            {
                Console.WriteLine($"Провел осмотр кардиолог {DoctorName}. Требуется лечение в отделении кардиологии");
            }
            else 
            {
                Console.WriteLine($"Провел осмотр кардиолог {DoctorName}. Лечение кардиолога не требуется");
             }
            patient.IsIll();
        }
    }
}
