using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsBars
{
    class CalculatorSubsidy : ISubsidyCalculation,IValidateSubsidia
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;

        public Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            string status = "Расчет началася";
            OnNotify(this, status);
            Charge charge = new Charge { ServiceId = volumes.HouseId, HouseId = volumes.HouseId, Month = volumes.Month, Value = volumes.Value * tariff.Value };
            status = "Расчет закончен";
            OnNotify(this, status);
            return charge;
        }

        public bool ValidateVolumeAndTarrif(Volume volume, Tariff tariff)
        {
            if (volume.HouseId == tariff.HouseId & volume.ServiceId == tariff.ServiceId)
            {
                return true;
            }
            return false;
            
        }

        public bool ValidateVolumeValue(Volume volume)
        {
            if (volume.Value < 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateTarifValue(Tariff tariff)
        {
            if (tariff.Value <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
