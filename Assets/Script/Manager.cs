using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager manager ;
    public AddBallToStore AddBallToStoreController;
    private int level;
    public int coin;
    public bool joystickActivated;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI coinTextInStore;
    [HideInInspector]public GameObject joystickRight;
    [HideInInspector]public GameObject joysticktLeft;
    public int[] stats;
    public string[] statsDate;
    [HideInInspector]public GameObject menuPanelController;
    [HideInInspector]public AudioSource ballHitPlatformAudioSource;
    public List<GameObject> customPlatforms;
    public List<int> ballBought;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (!manager)
        {
            manager = this;
        }
        else
        {
             Destroy(this.gameObject);
        }
        level = 0;
    }
    
    public void setBestScore()
    {
        int tempLevel = level;
        string tempDate = System.DateTime.Now.ToShortDateString();
        gameObject.SetActive(true);
        for (int i = 0; i < 4; i++)
        { 
            if (stats[i]<=tempLevel)
            {
                int temp = stats[i];
                stats[i] = tempLevel;
                tempLevel = temp;

                string tempD = statsDate[i];
                statsDate[i] = tempDate;
                tempDate = tempD;
            }
        }
        SaveSystem.SaveDataPlayer(Manager.manager.stats,Manager.manager.statsDate,Manager.manager.coin, Manager.manager.ballBought,CurrentBall.numberOfList );
        menuPanelController.GetComponent<MenuPanelController>().setStats(stats,statsDate);
    }

    void Start()
    {
        ballBought = new List<int>();
        ballHitPlatformAudioSource = GetComponent<AudioSource>();
        stats = new int[4];
        statsDate = new string[4];
        menuPanelController = GameObject.Find("MenuPanel");
        // load data
        if ( SaveSystem.LoadDataPlayer() != null)
        {
           SaveStats stats = SaveSystem.LoadDataPlayer();
           statsDate = stats.statsDate;
           this.stats = stats.stats;
           coin = stats.coin;
           ballBought = stats.ballsBought;
           CurrentBall.numberOfList = stats.nomberOfCurrentBall;
           coinText.SetText(coin.ToString());
        }
        else
        {
            coin = 0;
            ballBought.Add(0);
            CurrentBall.numberOfList = 0;
        }
        Time.timeScale = 0;
        level = 0;
        joystickActivated = true;
        joysticktLeft = GameObject.Find("JoystickLeft");
        joystickRight = GameObject.Find("JoystickRight");
        menuPanelController.GetComponent<MenuPanelController>().setStats(this.stats, statsDate);
    }

    public void updateLevel()
    {
        level++;
        coin = coin+ 10 + level;
        levelText.SetText(level.ToString());
        coinText.SetText(coin.ToString());
    }

    public void resetStats()
    {
        level = 0;
        levelText.SetText(level.ToString());
    }

    public int getLevel()
    {
        return level;
    }

    public void setLevel(int level)
    {
        this.level = level;
        levelText.SetText(level.ToString());
    }

    public void setCoinText()
    {
        coinText.text = coin.ToString();
    }
    public void setCoinTextInStore()
    {
        coinTextInStore.text = coin.ToString();
    }
    
}
