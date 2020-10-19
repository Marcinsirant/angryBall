using System.Globalization;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string gameId = "3851087";
    bool testMode = false;
    ShowResult showResult;
    public int panel;

    public void setPanel(int number)
    {
        panel = number;
    }

    void Start () {
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);
    }
    
    public void ViewAd()
    {
        if (Advertisement.IsReady())
        {
            Debug.Log("ads");
            Advertisement.Show("rewardedVideo");
            
        }
        else
        {
            Debug.Log("no ads");
        }
    }
    
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        
        if (showResult == ShowResult.Finished)
        {
            if (panel == 0)
            {
                Manager.manager.menuPanelController.GetComponent<MenuPanelController>().StartGameWithoutResetLevel();
            }
            else
            {
                Manager.manager.coin += 250;
                Manager.manager.setCoinTextInStore();
            }
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }
    
    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == gameId) {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }
    
}