using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Manager.manager.menuPanelController.SetActive(true);
            MenuPanelController menuPanelController = Manager.manager.menuPanelController.GetComponent<MenuPanelController>();
            menuPanelController.resumeMenuActiveRespawn();
            Manager.manager.setBestScore();
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}
