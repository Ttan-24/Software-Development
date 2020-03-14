using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public class BuildingController
    {
        public BuildingController(string id)
        {
            buildingID = id.ToLower();
            currentState = "out of hours";
        }
        string buildingID;
        string currentState;

        public string GetCurrentState()
        {
            return currentState;
        }

        public bool SetCurrentState(string state)
        {
            state = state.ToLower();
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

        public string GetBuildingID()
        {
            return buildingID;
        }

        public void SetBuildingID(string id)
        {
            buildingID = id.ToLower();
        }

        //string GetStatusReport()
        //{
        //    return;
        //}
    }
}
