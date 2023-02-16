using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerAttack : MonoBehaviour
{
    Animator _animator;

    [SerializeField]
    public float _maxAttackTime;

    [SerializeField]
    public GameObject _Player;

    [SerializeField]
    public string _meshName;

    float _attackTime;
    public bool _isAttacking;

    public bool _IsPunching = false;
    //public bool _IsRunning = false;
    static public int _playerAttackPower;


    // Start is called before the first frame update
    void Start()
    {
        var temp = FindChildGameObjectByName(_Player, _meshName);
        _animator = temp.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu._isGamePaused)
            return;

    
            BreakObject();

    }
    void BreakObject()
    {

        //If left click do break logic
        if (Input.GetKeyDown(KeyCode.Mouse0) && _attackTime < _maxAttackTime)
        {
            _attackTime += Time.deltaTime;
            _isAttacking = true;
            _animator.SetBool("IsPunching", true);
        }
        //If mouse button is released, reset attack time and reset bool
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _attackTime = 0f;
            _isAttacking = false;
            _animator.SetBool("IsPunching", false);
        }
        else //If attack time exceeds
        {
            _isAttacking = false;
            _animator.SetBool("IsPunching", false);
        }

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

