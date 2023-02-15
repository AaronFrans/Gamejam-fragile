using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    [SerializeField]
    private static int _StrenghtPriceIncrease = 2000;

    private static int _maxStrenghtLVL = 3;
    private static int _currentStrenghtLVL = 0;

    [SerializeField]
    private static int _SpeedPriceIncrease = 2200;

    private static int _maxSpeedLVL = 2;
    private static int _currentSpeedLVL = 0;

    // Start is called before the first frame update
    void Start()
    {
    }


    public void BuyStrength(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        _currentStrenghtLVL++;
        _playerAttack._playerAttackPower++;
        if (_maxStrenghtLVL > _currentStrenghtLVL)
        {

            shopMenuItem.cost += _StrenghtPriceIncrease;

            shopMenuItem.SetText();

            PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);

            switch (_currentStrenghtLVL)
            {
                case 1:
                    shopMenuItem.upgradeText.text = "Strength LV2";
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    break;
                case 2:
                    shopMenuItem.upgradeText.text = "Strength LVMAX";
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    break;
                default:
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    break;
            }

        }
        else
        {
            shopMenuItem.cost = -1;
            shopMenuItem.SetSoldOut();
            PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        }

    }

    public void BuySpeed(ShopMenuItem shopMenuItem)
    {

        Currency.TotalCurrency -= shopMenuItem.cost;
        _currentSpeedLVL++;
        if (_maxSpeedLVL > _currentSpeedLVL)
        {

            shopMenuItem.cost += _SpeedPriceIncrease;

            shopMenuItem.SetText();

            PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);

            switch (_currentSpeedLVL)
            {
                case 1:
                    shopMenuItem.upgradeText.text = "Speed LV2";
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    break;
                case 2:
                    shopMenuItem.upgradeText.text = "Speed LVMAX";
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    break;
                default:
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    break;
            }

        }
        else
        {
            shopMenuItem.cost = -1;
            shopMenuItem.SetSoldOut();
            PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        }

    }

    public void BuyDoubleValue(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = -1;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
    }

    public void BuyDoubleJump(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = -1;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
    }

    public void BuyGrapplingGun(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = -1;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
    }

    public void BuyWinGame(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = -1;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        // go to final scene
    }
}
