using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Lumin;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed;
    [HideInInspector]public bool newPlatformCreated;
    private GameObject respawnColider;
    public int distanceBetweenPlatform;
    private GameObject arrow;
    private bool rotationActive;
    public int platformLevel;

    enum PositionPlatform
    {
        up=0,
        right=1,
        down=2,
        left=3,
    }
    
    PositionPlatform setplatformPosition;
    
   

    private void Start()
    {
        respawnColider = GameObject.Find("Respawn");
        platformLevel = Manager.manager.getLevel();
        rotationActive = false;
        newPlatformCreated = false;
        setplatformPosition = (PositionPlatform) Random.Range(0,3);//(PositionPlatform) Random.Range(0,3);
        arrow = gameObject.transform.Find("Arrow").gameObject;
        arrow.transform.localRotation = Quaternion.Euler(0,90*(int)setplatformPosition,0);

    }


    private void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "Player")
            rotationActive = true;
        
        if (otherObject.gameObject.tag == "Player" && !newPlatformCreated)
        {
            Manager.manager.updateLevel();
            Manager.manager.ballHitPlatformAudioSource.Play();
            Debug.Log("inst");
            rotationActive = true;
            GameObject whichPlatform = Manager.manager.customPlatforms[Random.Range(0, Manager.manager.customPlatforms.Count)];
            Vector3 whichPlatformSizeV3d = whichPlatform.GetComponent<Renderer>().bounds.size;
            switch (setplatformPosition)
            {
                case PositionPlatform.up:
                    whichPlatformSizeV3d.x = 0;
                    break;
                case PositionPlatform.down:
                    whichPlatformSizeV3d.x = 0;
                    whichPlatformSizeV3d.z = -whichPlatformSizeV3d.z;
                    break;
                case PositionPlatform.left:
                    whichPlatformSizeV3d.x = -whichPlatformSizeV3d.x;
                    whichPlatformSizeV3d.z = 0;
                    break;
                case PositionPlatform.right:
                    whichPlatformSizeV3d.z = 0;
                    break;
            }

            Instantiate(whichPlatform,
                new Vector3(gameObject.transform.position.x + whichPlatformSizeV3d.x,
                    gameObject.transform.position.y - 15 * distanceBetweenPlatform,
                    gameObject.transform.position.z + whichPlatformSizeV3d.z), new Quaternion());
            newPlatformCreated = true;
            
            respawnColider.transform.localPosition = new Vector3(0, this.transform.position.y - 50, 0);
            
        }
    }
    
    void Update()
    {
        if (platformLevel+2 == Manager.manager.getLevel())
        {
            Destroy(gameObject);
        }
        
        if (rotationActive)
        {
            if (Manager.manager.joystickActivated)
            {
                transform.Rotate(Vector3.back, Manager.manager.joysticktLeft.GetComponent<Joystick>().Horizontal);
                transform.Rotate(Vector3.right, Manager.manager.joystickRight.GetComponent<Joystick>().Vertical);
            }
            else
            {

                Vector3 dir = Vector3.zero;

                dir.x = Input.acceleration.y;
                dir.z = Input.acceleration.x;

                if (dir.sqrMagnitude > 1) dir.Normalize();
                dir *= Time.deltaTime;

                transform.Rotate(Vector3.right, dir.x * rotationSpeed);
                transform.Rotate(Vector3.back, dir.z * rotationSpeed);


            }

        }


    }
}



