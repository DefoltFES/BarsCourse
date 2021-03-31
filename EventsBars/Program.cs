using System;
using ClassLibrary1;

namespace EventsBars
{
    class Program
    {
        static void Main(string[] args)
        {
            Volume volume = new Volume
            {
                HouseId = 1,
                ServiceId = 1,
                Month = DateTime.Today,
                Value = 8
            };
            Tariff tariff=new Tariff
            {
                HouseId = 1,
                ServiceId = 1,
                PeriodBegin = DateTime.Today,
                PeriodEnd = DateTime.Today,
                Value = 5
            };
            CalculatorSubsidy calc = new CalculatorSubsidy();
            calc.OnNotify += Notify;
            calc.CalculateSubsidy(volume,tariff);
           
        }

        private static void Notify(object sender, string e)
        {
            Console.WriteLine(e+" "+DateTime.Now);
        }
       
    }
}
