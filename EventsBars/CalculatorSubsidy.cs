using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsBars
{
    class CalculatorSubsidy : ISubsidyCalculation
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;

        public Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            OnNotify(this, $"Расчет начат {DateTime.Today.ToShortTimeString()} d");
            Charge charge = new Charge { ServiceId= volumes.HouseId,HouseId=volumes.HouseId,Month=volumes.Month,Value=volumes.Value*tariff.Value };
            OnNotify(this, $"Расчет закончен {DateTime.Today.ToShortTimeString()}");
            return charge;
        }
    }
}
