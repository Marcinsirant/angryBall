using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public List<Button> buttons;
    public AudioSource audioS;
    public void Start()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(TaskOnClick);
        }
    }
    void TaskOnClick(){
        audioS.Play();
    }
}
