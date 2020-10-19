using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onOfflight : MonoBehaviour
{
    public void ActiveGreen()
    {
        Manager.manager.joystickActivated = !Manager.manager.joystickActivated;
        if (Manager.manager.joystickActivated)
        {
           gameObject.GetComponent<Image>().color = Color.green; 
           Manager.manager.joystickRight.SetActive(true);
           Manager.manager.joysticktLeft.SetActive(true);
        }else
        {
           gameObject.GetComponent<Image>().color = Color.white; 
           Manager.manager.joystickRight.SetActive(false);
           Manager.manager.joysticktLeft.SetActive(false);
        }
    }
}
