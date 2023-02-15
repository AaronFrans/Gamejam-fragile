using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    private static int _StrenghtPriceIncrease = 2000;

    private static int _maxStrenghtLVL = 3;
    private static int _currentStrenghtLVL = 0;

    private static int _SpeedPriceIncrease = 2200;

    [SerializeField]
    private TextMeshProUGUI currency;

    private static int _maxSpeedLVL = 3;
    private static int _currentSpeedLVL = 0;

    // Start is called before the first frame update
    void Start()
    {
        currency.text = Currency.TotalCurrency.ToString();
    }


    private void Update()
    {
        currency.text = Currency.TotalCurrency.ToString();
    }


    public void BuyStrength(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        _currentStrenghtLVL++;
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
            shopMenuItem.cost = int.MaxValue;
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
            shopMenuItem.cost = int.MaxValue;
            shopMenuItem.SetSoldOut();
            PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        }

    }

    public void BuyDoubleValue(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = int.MaxValue;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        Currency._copperValue *= 2;
        Currency._silverValue *= 2;
        Currency._goldValue *= 2;
    }

    public void BuyDoubleJump(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = int.MaxValue ;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        _playerMovement._hasUnlockedDoubleJump = true;
    }

    public void BuyGrapplingGun(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = int.MaxValue;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
    }

    public void BuyWinGame(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = int.MaxValue;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        // go to final scene
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
