using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    private GameObject _self = null;


   [SerializeField]
   private AudioClip _breakAudio;


    [SerializeField] private string _name;
    [SerializeField] private GameObject _player;

    
    bool _isPlayerAttacking;
    bool _playerWithinRange;
    GameObject _playerLogicObject;


    private Currency.CurrencyType _rarity;


    // Start is called before the first frame update
    void Start()
    {
        if (_collider == null)
            Debug.Log("no _collider set");

        if (_self == null)
            Debug.Log("no _self set");

        SetMaterial();

        _playerLogicObject = FindChildGameObjectByName(_player, _name);
    }

    private void SetMaterial()
    {
        Array values = Enum.GetValues(typeof(Currency.CurrencyType));
        Random random = new Random();
        _rarity = (Currency.CurrencyType)values.GetValue(random.Next(values.Length));
        Material newMat = GetMaterialFromRarity();

        var _selfRender = _self.GetComponent<Renderer>();
        _selfRender.material = newMat;
    }

    private Material GetMaterialFromRarity()
    {
        Material newMat = null;
        switch (_rarity)
        {
            case Currency.CurrencyType.copper:
                newMat = Resources.Load("m_Copper", typeof(Material)) as Material;
                break;
            case Currency.CurrencyType.silver:
                newMat = Resources.Load("m_Silver", typeof(Material)) as Material;
                break;
            case Currency.CurrencyType.gold:
                newMat = Resources.Load("m_Gold", typeof(Material)) as Material;
                break;

        }
        return newMat;
    }

    // Update is called once per frame
    void Update()
    {
  
        _isPlayerAttacking = _playerLogicObject.GetComponent<_playerAttack>()._isAttacking;

        if (_isPlayerAttacking && _playerWithinRange)
            --_health;

        if(_health <= 0) //<= in case of 1 health with double damage (2)
            Destroy(_self);
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
