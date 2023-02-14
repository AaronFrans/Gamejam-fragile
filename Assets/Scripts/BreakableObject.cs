using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    //The collider for interactions
    [SerializeField]
    private BoxCollider _collider;

    // max amount of health
    [SerializeField]
    private float _health;

    [SerializeField]
    private GameObject _self;


    // Start is called before the first frame update
    void Start()
    {
        if (_collider == null)
            Debug.Log("no _collider set");

        if (_self == null)
            Debug.Log("no _self set");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hasHit;
            if (_collider.Raycast(ray, out hasHit, 100))
            {

                Debug.Log(_health);
                _health -= 1;
                if (_health <= 0)
                {
                    Destroy(_self);
                }
            }
        }
    }
}
