using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPanelController : MonoBehaviour
{
    public List<GameObject> pages;
    public GameObject backButton;
    public GameObject background;
    public GameObject resumeMenu;
    public TextMeshProUGUI levelText;

    public List<TextMeshProUGUI> statsGUI;
    
    public void setStats(int[] stats, string[] statsDate)
    {
        for (int i = 0; i < 4; i++) 
        {
            // string input = stats[i];
            // string result = Regex.Match(input, @"\d+(?!\D*\d)").Value;
            // Debug.Log(result);
            statsGUI[i].text = i+1 + ". " + statsDate[i] +" lvl: "+ stats[i];
        }
            
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Manager.manager.resetStats();
        PagesSetActiveFalse();
        background.SetActive(false);
        gameObject.SetActive(false);
        Manager.manager.setCoinText();
    }
    

    public void StartGameWithoutResetLevel()
    {
        Time.timeScale = 1;
        PagesSetActiveFalse();
        background.SetActive(false);
        gameObject.SetActive(false); 
    }

    public void RestartGame()
    {
        
        Manager.manager.setLevel(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartGame();
    }

    public void resumeMenuActive()
    {
        levelText.text = "LEVEL: "+Manager.manager.getLevel().ToString();
        Time.timeScale = 0;
        PagesSetActiveFalse();
        background.SetActive(true);
        resumeMenu.SetActive(true);
        resumeMenu.GetComponent<ResumeController>().Resume.SetActive(true);
        backButton.SetActive(true);
        SaveSystem.SaveDataPlayer(Manager.manager.stats,Manager.manager.statsDate,Manager.manager.coin, Manager.manager.ballBought,CurrentBall.numberOfList);
        
    }
    
    public void resumeMenuActiveRespawn()
    {
        levelText.text = "LEVEL: "+Manager.manager.getLevel().ToString();
        Time.timeScale = 0;
        PagesSetActiveFalse();
        background.SetActive(true);
        resumeMenu.SetActive(true);
        resumeMenu.GetComponent<ResumeController>().Resume.SetActive(false);
        backButton.SetActive(true);
    }
    

    public void PagesSetActiveFalse()
    {
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
    }

    public void backButtonSetActive(bool t)
    {
        backButton.SetActive(t);
    }
    
    public void ExitGame() {
        
        Application.Quit();
    }
}
