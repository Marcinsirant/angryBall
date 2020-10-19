using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBallToStore : MonoBehaviour
{
    public GameObject ballToBuyPrefab;
    public List<GameObject> ballPrefab;
    public List<GameObject> ballInStore;

    public void createObjectInStore()
    {
        ballInStore = new List<GameObject>();
        if (ballToBuyPrefab != null) {
            for (int i = 0; i < ballPrefab.Count; i++) {
                
                GameObject prefabInstance = Instantiate(ballToBuyPrefab);
                if (prefabInstance != null)
                {
                    
                    var myScriptReference = prefabInstance.GetComponent<BallToBuyController>();
                    myScriptReference.price = i * 500;
                    myScriptReference.numberOfList = i;
                    myScriptReference.addBallToStore = this;
                    ballInStore.Add(prefabInstance);
                    if (myScriptReference != null)
                    {
                        myScriptReference.ball = ballPrefab[i];
                    }
                    prefabInstance.transform.SetParent(this.transform);
                    prefabInstance.transform.localScale = new Vector3(1,1,1);
                }


                //prefabsGameLevel.transform.SetParent(gameObject.transform, true);
            }
        }
        Manager.manager.setCoinTextInStore();
    }

    public void deleteAllObjectInStore()
    {
        foreach (var VARIABLE in ballInStore)
        {
            Destroy(VARIABLE);
        }
    }

    public void buttonTextSet()
    {
        foreach (var ball in ballInStore)
        {
            BallToBuyController BallbuyController = ball.GetComponent<BallToBuyController>();
            if (BallbuyController.textBuyButton.text == "USED")
                BallbuyController.textBuyButton.text = "SET";
        }
    }
    
}
