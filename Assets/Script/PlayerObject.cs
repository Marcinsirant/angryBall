using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : MonoBehaviour
{
    public GameObject menuPanel;
    private GameObject prefabInstance;

    private void Start()
    {
        menuPanel = Manager.manager.menuPanelController;
        Debug.Log(CurrentBall.numberOfList);
        //gameObject.GetComponent<Rigidbody>().mass = Manager.manager.AddBallToStoreController.ballPrefab[CurrentBall.numberOfList].GetComponent<Rigidbody>().mass;
        //gameObject.transform.localScale = CurrentBall.oginalSize;
        //gameObject.GetComponent<MeshRenderer>().materials = Manager.manager.AddBallToStoreController.ballPrefab[CurrentBall.numberOfList].GetComponent<MeshRenderer>().sharedMaterials;
        prefabInstance = Instantiate(Manager.manager.AddBallToStoreController.ballPrefab[CurrentBall.numberOfList]);// create ball to game
        prefabInstance.transform.SetParent(this.transform);
        prefabInstance.transform.localPosition=new Vector3(0,5,0);
        prefabInstance.tag = "Player";

        GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineFreeLook>().Follow = prefabInstance.transform;
        GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineFreeLook>().LookAt = prefabInstance.transform;
    }
}