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
    private BoxCollider _collider = null;

    // max amount of health
    [SerializeField]
    private float _health = 0;

    [SerializeField]
    private GameObject _cubeGroup = null;

    [SerializeField] private string _name;
    [SerializeField] private GameObject _coinPrefab;

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
    private AudioSource _breakAudio;

    private Currency.CurrencyType _rarity;


    // Start is called before the first frame update
    void Start()
    {
        if (_collider == null)
            Debug.Log("no _collider set");

        if (_cubeGroup == null)
            Debug.Log("no _self set");

        _hasInstantiated = false;
        _player = GameObject.Find("Player");
        _currencyText = GameObject.Find("CurrencyText");
        _playerLogicObject = FindChildGameObjectByName(_player, _name);
        SetMaterial();
        _breakAudio = gameObject.GetComponentInChildren<AudioSource>();
    }

    private void SetMaterial()
    {
        Array values = Enum.GetValues(typeof(Currency.CurrencyType));
        Random random = new Random();

        _rarity = (Currency.CurrencyType)values.GetValue(random.Next(values.Length));
        SetColorFromRarity();
    }

    private void SetColorFromRarity()
    {
        switch (_rarity)
        {
            case Currency.CurrencyType.copper:
                _selfRender.material.color = new Color(1, 0, 0);
                _value = 100;
                break;
            case Currency.CurrencyType.silver:
                _selfRender.material.color = new Color(0, 1, 0);
                _value = 500;
                break;
            case Currency.CurrencyType.gold:
                _selfRender.material.color = new Color(0, 0, 1);
                _value = 1000;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
  
        _isPlayerAttacking = _playerLogicObject.GetComponent<_playerAttack>()._isAttacking;

        if (_isPlayerAttacking && _playerWithinRange)
            --_health;


        if(_health <= 0) //<= in case of 1 health with double damage (2)
        {
            DetermineCoins();
            if(!_hasInstantiated)
            {
                InstantiateCoins();
                _breakAudio.Play();
                Destroy(_cubeGroup);
                _hasInstantiated = true;
            }
            Destroy(gameObject, _breakAudio.clip.length);
        }
    }  

    void DetermineCoins()
    {


        List<Currency.CurrencyType> values = Enum.GetValues(typeof(Currency.CurrencyType)).Cast<Currency.CurrencyType>().ToList();
        Random random = new Random();


        while(_value > Currency._copperValue)
        {
             if(_value < Currency._silverValue)
            {
                values = values.Where(x => x != Currency.CurrencyType.silver).ToList();

            }
            else if(_value < Currency._goldValue)
            {
                values = values.Where(x => x!= Currency.CurrencyType.gold).ToList();

            }

            var coinRarity = values[random.Next(values.Count)];
            _coins.Add(coinRarity);
            _value -= Currency.DetermineValue(coinRarity);
            var currency =  _currencyText.GetComponent<Currency>();

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
        for(int i = 0; i < topParentGameObject.transform.childCount; ++i)
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
