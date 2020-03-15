using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public interface ILightManager
    {
        void SetLight(bool isON, int lightID);
        string GetStatus();
        void SetAllLights(bool isOn);
    }
}
