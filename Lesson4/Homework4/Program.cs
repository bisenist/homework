namespace Homework4
{
    public class Programm
    {
        public static void Main()
        {
            Counter counter = new Counter();
            Handler1 handler1 = new Handler1();
            Handler2 handler2 = new Handler2();

            counter.onCount += handler1.Say;
            counter.onCount += handler2.SayAgain;

            counter.CycleCounter();
        }
    }
}