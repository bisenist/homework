



namespace Homework3
{
    public class Programm
    {
        public static void Main()
        {
            Patient chel1 = new Patient("Иванов И.И.", 20)
            {
                HeartSymptom = true
            };
            chel1.IsIll();

            Patient chel2 = new Patient("Васильева В.В.", 60)
            {
                LungsSymptom = true,
                GastroSymptom = true
            };
            chel2.IsIll();

            Pulmonologist doc1 = new Pulmonologist("Касьяновна В. К.", 30, 3);
            Cardiologist doc2 = new Cardiologist("Петрова А. А.", 35, 8);
            Gastroenterologist doc3 = new Gastroenterologist("Романов С. С.", 40, 13);

            doc1.ShowInfo();
            doc2.ShowInfo();
            doc3.ShowInfo();

            //осмотры и лечение первого пациента
            chel1.ShowInfo();
            doc3.MedicalExamination(chel1);
            doc2.MedicalExamination(chel1);
            doc2.Cure(chel1);
            chel1.IsIll();
            chel1.ShowInfo();
            
            //осмотры и лечения второго пациента
            chel2.ShowInfo();
            doc2.MedicalExamination(chel2);
            doc2.Cure(chel2); //для проверки правильности работы, что лечить нечего
            doc3.MedicalExamination(chel2);
            doc3.Cure(chel2);
            chel2.ShowInfo();
            doc1.MedicalExamination(chel2);
            doc1.Cure(chel2);
            chel2.ShowInfo();
        }
    }
}
