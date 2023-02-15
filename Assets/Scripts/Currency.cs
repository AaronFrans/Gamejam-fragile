using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _text = null;

    [SerializeField]
    static public int _copperValue = 30;

    [SerializeField]
    static public int _silverValue = 50;

    [SerializeField]
    static public int _goldValue = 100;

    [SerializeField]
    private int _finalUpgradePrice;

    static public int TotalCurrency { get; set; } = 0;
     
    public enum CurrencyType
    {
        copper,
        silver,
        gold
    }

    public int currency = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (_text == null)
            Debug.Log("no _text set");

        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddToCurrecny(CurrencyType.copper);
        }

        if (Input.GetMouseButtonDown(1))
        {
            AddToCurrecny(CurrencyType.silver);
        }

        if (Input.GetMouseButtonDown(2))
        {
            AddToCurrecny(CurrencyType.gold);
        }
    }


    public void AddToCurrecny(CurrencyType type)
    {
        switch (type)
        {
            case CurrencyType.copper:
                {
                    currency = Math.Min(currency + _copperValue, _finalUpgradePrice);
                }
                break;
            case CurrencyType.silver:
                {
                    currency = Math.Min(currency + _silverValue, _finalUpgradePrice);
                }
                break;
            case CurrencyType.gold:
                {
                    currency = Math.Min(currency + _goldValue, _finalUpgradePrice);
                }
                break;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = currency.ToString();
    }

    static public int DetermineValue(CurrencyType type)
    {
        switch (type)
        {
            case CurrencyType.copper:
                return _copperValue;
                
            case CurrencyType.silver:
                return _silverValue;

            case CurrencyType.gold:
                return _goldValue;
        }

        return _copperValue;
    }
}
