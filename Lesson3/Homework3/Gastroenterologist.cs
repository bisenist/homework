using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework3
{
    public class Gastroenterologist : Doctor
    {

        public string Speciality { get; } = "Гастроэнтеролог";

        public Gastroenterologist (string name, int age, int experience) : base (name, age, experience) //конструктор
        {
        }

        public override void ShowInfo() => Console.WriteLine($"Доктор. ФИО: {DoctorName}  Возраст: {DoctorAge} "
                                                            + $"Специальность: {Speciality}  Стаж: {Experience}");

        public bool Cure(Patient patient)
        {
            if (patient.GastroSymptom)
            {
                patient.GastroSymptom = false;
                Console.WriteLine($"Пациент {patient.PatientName} прошел лечение гастроэнтеролога {DoctorName}. Проблемы с ЖКТ больше не беспокоят");
            }
            else
            {
                Console.WriteLine($"Пациенту {patient.PatientName} лечение гастроэнтеролога не требуется. Лечение не проведено");
            }
            patient.IsIll();
            return patient.GastroSymptom;
        }

        public void MedicalExamination(Patient patient) //осмотр пациента специалистом
        {
            if (patient.GastroSymptom)
            {
                Console.WriteLine($"Провел осмотр гастроэнтеролог {DoctorName}. Требуется лечение в отделении гастроэнтерологии");
            }
            else
            {
                Console.WriteLine($"Провел осмотр гастроэнтеролог {DoctorName}. Лечение гастроэнтеролога не требуется");
            }
            patient.IsIll();
        }
    }
}