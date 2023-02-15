using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _CoinBehavior : MonoBehaviour
{

    [SerializeField] public Vector3 _desiredDirection;
    [SerializeField] public float _velocity;
    public Currency.CurrencyType _currentType;

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
        // print(_currentType.ToString());
        _xSpread = Random.Range(-1f, 1f);
        _ySpread = Random.Range(0.5f, 1f);
        _zSpread = Random.Range(-1f, 1f);

        _Rigidbody = GetComponent<Rigidbody>();
    }   

    // Update is called once per frame
    void Update()
    {

        _TotalSpread = new Vector3(_xSpread, _ySpread, _zSpread).normalized * _frustrumSize;
        
        //transform.rotation = Quaternion.Euler(_TotalSpread) * transform.rotation;
        _Rigidbody.AddForce(_TotalSpread);

        //_animTime += Time.deltaTime;
        //
        //_animTime = _animTime % 5;
        //
        //transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 10f, 5f, _animTime / 5f);



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Add value to total
            
           // Destroy(gameObject);
        }
    }
}
