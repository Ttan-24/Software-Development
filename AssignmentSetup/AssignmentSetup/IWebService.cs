using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public interface IWebService
    {
        void LogFireAlarm(string logDetails);
        void LogEngineerRequired(string logDetails);
    }
}
