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
            Charge charge = null;
            try
            {
               
                OnNotifyCall("Расчет начат");
                charge = new Charge { ServiceId = volumes.HouseId, HouseId = volumes.HouseId, Month = volumes.Month, Value = volumes.Value * tariff.Value };
                OnNotifyCall("Расчет закончен");
                return charge;           
            }
            catch(Exception ex)
            {
                var turple = new Tuple<string, Exception>("Ошибка", ex);
                OnExceptionCall(turple);
                throw;
            }
            finally
            {
                
            }
            return charge;

        }

        public bool ValidateVolumeAndTarrif(Volume volume, Tariff tariff)
        {

            if (volume.HouseId == tariff.HouseId & volume.ServiceId == tariff.ServiceId &ValidateVolumeValue(volume)&ValidateTarifValue(tariff))
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

        protected virtual void OnNotifyCall(string  e)
        {
            var handler = OnNotify;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnExceptionCall(Tuple<string,Exception> tuple)
        {
            var handler = OnException;
            if (handler != null)
            {
                handler(this, tuple);
            }
        }
    }
}
