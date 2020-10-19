using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallToBuyController : MonoBehaviour
{
    public AddBallToStore addBallToStore;
    public GameObject ball;
    public Vector3 orginalSize;
    public Button buyButton;
    public int numberOfList;
    public TextMeshProUGUI textBuyButton;
    public TextMeshProUGUI textWeight;
    public TextMeshProUGUI textSize;
    public int price;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textSize.SetText("SIZE: "+(int)ball.transform.localScale.x);
        if (Manager.manager.ballBought.Contains(numberOfList))
            textBuyButton.SetText("SET");
        else
            textBuyButton.SetText($"{price}-BUY");
        
        orginalSize = ball.transform.localScale;
        GameObject prefabInstance = Instantiate(ball);
        prefabInstance.transform.SetParent(this.transform);
        ball = prefabInstance;
        
        ball.transform.localPosition = new Vector3(0,32,-100);
        ball.layer = 5; //UI
        foreach (Transform child in ball.transform)
        {
            child.gameObject.layer = 5;
        }
       
        buyButton.onClick.AddListener(clickBuyButton);
        
        textWeight.SetText("SPEED: "+(100-100*ball.GetComponent<Rigidbody>().drag));
        ball.transform.localScale = new Vector3(100,100,100);
    }

    void clickBuyButton()
    {
        if (textBuyButton.text.Contains("BUY"))
        {
            
            Manager.manager.ballBought.Add(numberOfList);
            if (!(Manager.manager.coin-price<0))
            {
               Manager.manager.coin -= price;
               textBuyButton.SetText("SET"); 
            }
            Manager.manager.setCoinTextInStore();
            
        }else if (textBuyButton.text.Contains("SET"))
        {
            addBallToStore.buttonTextSet();
            CurrentBall.numberOfList = numberOfList;
            ball.transform.localScale = new Vector3(100,100,100);
            textBuyButton.SetText("USED");
            
        }else if (textBuyButton.text.Contains("USED"))
        {
            addBallToStore.buttonTextSet();
            CurrentBall.numberOfList = numberOfList;
            ball.transform.localScale = new Vector3(100,100,100);
            textBuyButton.SetText("USED");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ball.transform.Rotate(0.5f,0.7f,0.1f,Space.Self);
    }
}
