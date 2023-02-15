using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerAttack : MonoBehaviour
{

    [SerializeField]
    public float _maxAttackTime;

    float _attackTime;
    public bool _isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BreakObject();

    }
    void BreakObject()
    {

        //If left click do break logic
        if (Input.GetKeyDown(KeyCode.Mouse0) && _attackTime < _maxAttackTime)
        {
            _attackTime += Time.deltaTime;
            _isAttacking = true;
        }
        //If mouse button is released, reset attack time and reset bool
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _attackTime = 0f;
            _isAttacking = false;
        }
        else //If attack time exceeds
        {
            _isAttacking = false;
        }

        //if(_isAttacking)
        //    print(_isAttacking);
    }
}
