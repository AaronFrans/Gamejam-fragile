using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        if (_collider == null)
            Debug.Log("no _collider set");

        if (_self == null)
            Debug.Log("no _self set");

        _playerLogicObject = FindChildGameObjectByName(_player, _name);
    }

    // Update is called once per frame
    void Update()
    {
  
        _isPlayerAttacking = _playerLogicObject.GetComponent<_playerAttack>()._isAttacking;

        if (_isPlayerAttacking && _playerWithinRange)
            --_health;

        if(_health <= 0) //<= in case of 1 health with double damage (2)
        {
            AudioSource.PlayClipAtPoint(_breakAudio, transform.position);
            Destroy(_self);
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
