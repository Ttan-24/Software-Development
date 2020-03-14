using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public class BuildingController
    {
        // Constructors
        public BuildingController(string id)
        {
            buildingID = id.ToLower();
            currentState = "out of hours";
            previousState = currentState;
        }
        public BuildingController(string id, string startState)
        {
            buildingID = id.ToLower();
            if (startState == "open" || startState == "out of hours" || startState == "closed")
            {
                
                currentState = startState.ToLower();
            }
            else
            {
                throw new System.ArgumentException("Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'");
                 
            }
            previousState = currentState;
        }

        // Member variables
        string buildingID;
        string currentState;
        string previousState;

        public string GetCurrentState()
        {
            return currentState;
        }

        public bool SetCurrentState(string state)
        {
            state = state.ToLower();
            // set the new currentState
            if (state == currentState)
            {
                return true;
            }
            else
            {
                if (state == "closed" || state == "out of hours" || state == "open" || state == "fire drill" || state == "fire alarm")
                {
                    if (state == "fire alarm" || state == "fire drill")
                    {
                        //the current state should reset to the previous state
                        previousState = currentState;
                        currentState = state;
                        return true;
                    }
                    else if (currentState == "fire alarm" || currentState == "fire drill")
                    {
                        currentState = previousState;
                        return true;
                    }
                    else
                    {
                        currentState = state;
                        return true;
                    }
                }
                else
                {
                    return false;
                }
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
