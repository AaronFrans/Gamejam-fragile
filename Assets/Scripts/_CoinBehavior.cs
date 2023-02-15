using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CoinBehavior : MonoBehaviour
{
    Currency.CurrencyType _currentType;
    // Start is called before the first frame update
    void Start()
    {
        _currentType = (Currency.CurrencyType)Random.Range(0, 3);
        print(_currentType.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Add value to total
            
            Destroy(gameObject);
        }
    }
}
