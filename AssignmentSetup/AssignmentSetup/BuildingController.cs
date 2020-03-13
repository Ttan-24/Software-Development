using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public class BuildingController
    {
        BuildingController(string id)
        {
            buildingID = id.ToLower();
            currentState = "out of hours";
        }
        string buildingID;
        string currentState;

        string GetCurrentState()
        {
            return currentState;
        }

        bool SetCurrentState(string state)
        {
            // set the new currentState
            if (state == "closed" || state == "out of hours" || state == "open" || state == "fire drill" || state == "fire alarm")
            {
                currentState = state;
                return true;
            }
            else
            {
                return false;
            }
        }

        string GetBuildingID()
        {
            return buildingID;
        }

        void SetBuildingID(string id)
        {
            buildingID = id.ToLower();
        }

        //string GetStatusReport()
        //{
        //    return;
        //}
    }
}
