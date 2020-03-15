using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public interface ILightManager
    {
        string GetStatus();
        void SetAllLights(bool isOn);
    }
}
