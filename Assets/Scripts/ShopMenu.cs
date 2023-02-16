using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currency;

    [Header("UI Images")]
    [SerializeField] private Image _StrengthImage;
    [SerializeField] private Image _SpeedImage;


    [Header("Speed Images")]
    [SerializeField] private Sprite _Speed1;
    [SerializeField] private Sprite _Speed2;

    [Header("Strength Images")]
    [SerializeField] private Sprite _Strength1;

    
    
    private static int _StrenghtPriceIncrease = 2000;

    private static int _maxStrenghtLVL = 2;
    private static int _currentStrenghtLVL = 0;

    private static int _SpeedPriceIncrease = 2200;

    private static int _maxSpeedLVL = 3;
    private static int _currentSpeedLVL = 0;

    // Start is called before the first frame update
    void Start()
    {
        currency.text = Currency.TotalCurrency.ToString();
        Cursor.lockState = CursorLockMode.Confined;
    }


    private void Update()
    {
        currency.text = Currency.TotalCurrency.ToString();
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
                    shopMenuItem.upgradeText.text = "Strength LVMAX";
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    _StrengthImage.sprite = _Strength1;
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
        _playerMovement._movementSpeed += 3f;
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
                    _SpeedImage.sprite = _Speed1;
                    break;
                case 2:
                    shopMenuItem.upgradeText.text = "Speed LVMAX";
                    PlayerPrefs.SetString(shopMenuItem.prefName + "Text", shopMenuItem.upgradeText.text);
                    _SpeedImage.sprite = _Speed2;
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
        BreakableObject._copperValue *= 2;
        BreakableObject._silverValue *= 2;
        BreakableObject._goldValue *= 2;
    }

    public void BuyDoubleJump(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = int.MaxValue ;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        _playerMovement._hasUnlockedDoubleJump = true;
    }

    public void BuyJumpHeight(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = int.MaxValue;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        _playerMovement._jumpforce += 2f;
    }

    public void BuyWinGame(ShopMenuItem shopMenuItem)
    {
        Currency.TotalCurrency -= shopMenuItem.cost;
        shopMenuItem.cost = int.MaxValue;
        shopMenuItem.SetSoldOut();
        PlayerPrefs.SetInt(shopMenuItem.prefName, shopMenuItem.cost);
        // go to final scene

        SceneManager.LoadScene("EndScreen");
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("MainLevel");
    }
}
