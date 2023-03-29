using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class Pulmonologist : Doctor 
    {
        public string Speciality { get; } = "Пульмонолог";

        public Pulmonologist (string name, int age, int experience) : base(name, age, experience) //конструктор
        {
        }

        public override void ShowInfo() => Console.WriteLine($"Доктор. ФИО: {DoctorName}  Возраст: {DoctorAge} "
                                                            +$"Специальность: {Speciality}  Стаж: {Experience}");

        public bool Cure(Patient patient)
        {
            if (patient.LungsSymptom)
            {
                patient.LungsSymptom = false;
                Console.WriteLine($"Пациент {patient.PatientName} прошел лечение пульмонолога {DoctorName}. Проблемы с дыхательной системой больше не беспокоят");
            }
            else
            {
                Console.WriteLine($"Пациенту {patient.PatientName} лечение пульмонолога не требуется. Лечение не проведено");
            }
            patient.IsIll();
            return patient.LungsSymptom;
        }

        public void MedicalExamination(Patient patient) //осмотр пациента специалистом
        {
            if (patient.LungsSymptom)
            {
                Console.WriteLine($"Провел осмотр пульмонолог {DoctorName}. Требуется лечение в отделении пульмонологии");
            }
            else
            {
                Console.WriteLine($"Провел осмотр пульмонолог {DoctorName}. Лечение не требуется");
            }
            patient.IsIll();
        }
    }
}