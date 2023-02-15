using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuItem : MonoBehaviour
{


    [SerializeField]
    public TextMeshProUGUI buttonText = null;

    [SerializeField]
    public Button button = null;


    [SerializeField]
    public TextMeshProUGUI upgradeText = null;

    [SerializeField]
    public int cost;
    
    [SerializeField]
    public string prefName;

    // Start is called before the first frame update
    void Start()
    {

        cost = Math.Max(PlayerPrefs.GetInt(prefName, 0), cost);

        if (buttonText == null)
            Debug.Log("no _buttonText set");

        if (button == null)
            Debug.Log("no _upgradeText set");

        SetText();

    }


    void Update()
    {
        if (Currency.TotalCurrency < cost)
            button.interactable = false;
        else if (cost == -1)
        {
            button.interactable = false;
        }
        else
            button.interactable = true;
    }

    public void SetText()
    {
        buttonText.text = cost.ToString();

        upgradeText.text = PlayerPrefs.GetString(prefName + "Text", upgradeText.text);

        if (Currency.TotalCurrency < cost)
            button.interactable = false;
        else if(cost == -1)
        {
            button.interactable = false;
        }
        else
            button.interactable = true;
    }

   public  void SetSoldOut()
    {
        buttonText.text = "Sold Out!";
        button.interactable = false;
    }
}
