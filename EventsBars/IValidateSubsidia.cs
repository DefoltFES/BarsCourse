using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace EventsBars
{
    interface IValidateSubsidia
    {
        bool ValidateVolumeAndTarrif(Volume volume,Tariff tariff);
        bool ValidateVolumeValue(Volume volume);
        bool ValidateTarifValue(Tariff volume);
    }
}
