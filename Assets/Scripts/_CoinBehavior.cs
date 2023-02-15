using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _CoinBehavior : MonoBehaviour
{

    [SerializeField] public float _scaleLimitMin;
    [SerializeField] public float _scaleLimitMax;

    public Currency.CurrencyType _currentType;

    private MeshRenderer _selfRender;
    private float _xSpread;
    private float _ySpread;
    private float _zSpread;
    public int _frustrumSize;
    Vector3 _TotalSpread;

    Rigidbody _Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _currentType = (Currency.CurrencyType)Random.Range(0, 3);


        _Rigidbody = GetComponent<Rigidbody>();
        _selfRender = GetComponent<MeshRenderer>();

        float scaleLimit = Random.Range(_scaleLimitMin, _scaleLimitMax);
        Vector3 direction = Random.insideUnitCircle;
        direction.z = direction.y; // circle is at Z units 
        direction.y = 1; // circle is at Z units 

        _Rigidbody.AddForce(direction * scaleLimit);
        UpdateColor();
    }

    public void UpdateColor()
    {
        switch (_currentType)
        {
            case Currency.CurrencyType.copper:
                _selfRender.material.color = new Color(1, 0, 0);
                
                break;
            case Currency.CurrencyType.silver:
                _selfRender.material.color = new Color(0, 1, 0);
                
                break;
            case Currency.CurrencyType.gold:
                _selfRender.material.color = new Color(0, 0, 1);
               
                break;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            Destroy(gameObject.transform.parent.gameObject, 2);
    }

}
