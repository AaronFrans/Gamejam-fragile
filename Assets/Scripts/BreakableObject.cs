using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class BreakableObject : MonoBehaviour
{
    //The collider for interactions
    [SerializeField]
    private MeshCollider _collider = null;


    [SerializeField]
    private GameObject _cubeGroup = null;

    [SerializeField] private string _name;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private _MeshShatter _meshShatter;
    [SerializeField] private AudioClip _breakClip;
    [SerializeField] private AudioClip _noBreakClip;

    [SerializeField]
    private Renderer _selfRender;


    private int _value;
    private bool _isPlayerAttacking;
    private bool _playerWithinRange;
    private bool _hasInstantiated;
    private GameObject _player;
    private GameObject _playerLogicObject;
    private GameObject _currencyText;
    private List<Currency.CurrencyType> _coins = new List<Currency.CurrencyType>();
    private AudioSource _potAudio;

    private Currency.CurrencyType _rarity;

    static public int _copperValue = 100;
    static public int _silverValue = 500;
    static public int _goldValue = 1000;


    // Start is called before the first frame update
    void Start()
    {
        if (_collider == null)
            Debug.Log("no _collider set");

        if (_cubeGroup == null)
            Debug.Log("no _cubeGroup set");

        _hasInstantiated = false;
        _player = GameObject.Find("Player");
        _currencyText = GameObject.Find("CurrencyText");
        if (_player != null)
            _playerLogicObject = FindChildGameObjectByName(_player, _name);
        SetMaterial();
        _potAudio = gameObject.GetComponentInChildren<AudioSource>();
    }

    private void SetMaterial()
    {
        Array values = Enum.GetValues(typeof(Currency.CurrencyType));
        Random random = new Random();

        _rarity = (Currency.CurrencyType)values.GetValue(random.Next(values.Length));
        SetPotFromRarity();
    }

    private void SetPotFromRarity()
    {
        switch (_rarity)
        {
            case Currency.CurrencyType.copper:
                _selfRender.material.color = new Color(171f / 255f, 116f / 255f, 64f / 255f);
                _value = _copperValue;

                break;
            case Currency.CurrencyType.silver:
                _selfRender.material.color = new Color(192 / 255f, 192 / 255f, 192 / 255f);
                _value = _silverValue;

                break;
            case Currency.CurrencyType.gold:
                _selfRender.material.color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
                _value = _goldValue;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
            return;


        if (!GoblinAnimEventHandler.canHit)
           return;

        _isPlayerAttacking = _playerLogicObject.GetComponent<_playerAttack>()._isAttacking;


        if(_isPlayerAttacking && _playerWithinRange) //<= in case of 1 health with double damage (2)
        { 
            if(CanPlayerBreakPot())
            {
                if(!_hasInstantiated)
                {
                    _meshShatter.ShatterMesh(_selfRender.material.color);
                    Destroy(_cubeGroup);
                    DetermineCoins();
                    InstantiateCoins();
                    _potAudio.clip = _breakClip;
                    _potAudio.Play();
                    Timer._hasStarted = true;
                    _hasInstantiated = true;
                }
                Destroy(gameObject, _potAudio.clip.length);
            }
            else

            {
                _potAudio.clip = _noBreakClip;
                _potAudio.Play();
            }
        }
    }

    bool CanPlayerBreakPot()
    {
        switch (_rarity)
        {
            case Currency.CurrencyType.copper:
                return true;
            case Currency.CurrencyType.silver:
                return _playerAttack._playerAttackPower >= 1;
            case Currency.CurrencyType.gold:
                return _playerAttack._playerAttackPower == 2;
            default:
                return false;

        }
    }

    void DetermineCoins()
    {


        List<Currency.CurrencyType> values = Enum.GetValues(typeof(Currency.CurrencyType)).Cast<Currency.CurrencyType>().ToList();
        Random random = new Random();


        while (_value > Currency._copperValue)
        {
            if (_value < Currency._silverValue)
            {
                values = values.Where(x => x != Currency.CurrencyType.silver).ToList();

            }
            else if (_value < Currency._goldValue)
            {
                values = values.Where(x => x != Currency.CurrencyType.gold).ToList();

            }

            var coinRarity = values[random.Next(values.Count)];
            _coins.Add(coinRarity);
            _value -= Currency.DetermineValue(coinRarity);
            var currency = _currencyText.GetComponent<Currency>();

            _currencyText.GetComponent<Currency>().AddToCurrecny(coinRarity);
        }

    }


    void InstantiateCoins()
    {
        foreach (var currentCoin in _coins)
        {
            var instantiatedCoin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);

            _CoinBehavior coinBehavior = instantiatedCoin.GetComponentInChildren<_CoinBehavior>();
            coinBehavior._currentType = currentCoin;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
            _playerWithinRange = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            _playerWithinRange = false;
    }

    private GameObject FindChildGameObjectByName(GameObject topParentGameObject, string gameObjectName)
    {
        for (int i = 0; i < topParentGameObject.transform.childCount; ++i)
        {

            if (topParentGameObject.transform.GetChild(i).name == gameObjectName)
                return topParentGameObject.transform.GetChild(i).gameObject;

            GameObject temp = FindChildGameObjectByName(topParentGameObject.transform.GetChild(i).gameObject, gameObjectName);

            if (temp != null)
                return temp;



        }


        return null;
    }
}
