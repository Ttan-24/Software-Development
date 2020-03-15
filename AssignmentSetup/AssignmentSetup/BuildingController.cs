using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public class LightManager : ILightManager
    {
        public bool allLights;
        public string GetStatus()
        {
            return "Lights,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,";
        }

        public void SetAllLights(bool isOn)
        {
            allLights = isOn;
        }
    }
    public class FireAlarmManager : IFireAlarmManager
    {
        public bool alarmIsOn;
        public string GetStatus()
        {
            return "Fire,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,";
        }

        public void SetAlarm(bool isActive)
        {
            alarmIsOn = isActive;
        }
    }
    public class DoorManager : IDoorManager
    {
        public bool canOpen = true;
        public bool allLocked = false;
        public string GetStatus()
        {
            return "Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,";
        }

        public bool OpenAllDoors()
        {
            if (canOpen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LockAllDoors()
        {
            allLocked = true;
            return true;
        }
    }
    public class WebService : IWebService
    {
        public string log;
        public void LogFireAlarm (string logDetails)
        {
            log = logDetails;
        }
    }
    public class EmailService : IEmailService
    {

    }
    public class BuildingController
    {
        private IWebService webservice = new WebService();
        private IEmailService emailService = new EmailService();
        private ILightManager lightManager = new LightManager();
        private IDoorManager doorManager = new DoorManager();
        private IFireAlarmManager fireAlarmManager = new FireAlarmManager();

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
        public BuildingController(string id, ILightManager iLightManager, IFireAlarmManager iFireAlarmManager, IDoorManager iDoorManager, IWebService iWebService, IEmailService iEmailService)
        {
            buildingID = id.ToLower();
            lightManager = iLightManager;
            doorManager = iDoorManager;
            fireAlarmManager = iFireAlarmManager;
            webservice = iWebService;
            emailService = iEmailService;
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
                        fireAlarmManager.SetAlarm(true);
                        doorManager.OpenAllDoors();
                        lightManager.SetAllLights(true);
                        webservice.LogFireAlarm("fire alarm");
                        return true;
                    }
                    else if (currentState == "fire alarm" || currentState == "fire drill")
                    {
                        currentState = previousState;
                        return true;
                    }
                    else
                    {
                        if (state == "open")
                        {
                            bool wasAbleToOpen = doorManager.OpenAllDoors();
                            if (wasAbleToOpen)
                            {
                                currentState = state;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (state == "closed")
                        {
                            bool wasAbleToClose = doorManager.LockAllDoors();
                            if (wasAbleToClose)
                            {
                                currentState = state;
                                lightManager.SetAllLights(false);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
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

        public string GetStatusReport()
        {
            return (lightManager.GetStatus() + doorManager.GetStatus() + fireAlarmManager.GetStatus());
        }
    }
}
