using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffSound : MonoBehaviour
{
    public GameObject soundOn;
    private bool soundIsOn;

    private void Start()
    {
        soundIsOn = true;
    }

    public void ActiveSound()
    {

        if (!soundIsOn)
        {
            AudioListener.volume = 1;
            gameObject.GetComponent<Image>().color = Color.green;
            soundOn.SetActive(true);
            soundIsOn = true;
        }
        else
        {
            AudioListener.volume = 0;
            gameObject.GetComponent<Image>().color = Color.white;
            soundOn.SetActive(false);
            soundIsOn = false;
        }



    }
}