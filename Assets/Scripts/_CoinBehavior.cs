using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _CoinBehavior : MonoBehaviour
{

    [SerializeField] public float _scaleLimitMin;
    [SerializeField] public float _scaleLimitMax;
    [SerializeField] private Patch _coinPatch;

    public Currency.CurrencyType _currentType;

    private AudioSource _coinSource;
    private MeshRenderer _selfRender;
    private bool _hasPlayed;
    private bool _hasSpawned;
    private string CONFIRM_SPAWN;
    public int _frustrumSize;

    Rigidbody _Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _currentType = (Currency.CurrencyType)Random.Range(0, 3);

        _coinSource = GetComponent<AudioSource>();
        _Rigidbody = GetComponent<Rigidbody>();
        _selfRender = GetComponent<MeshRenderer>();
        _hasSpawned= false;
        CONFIRM_SPAWN = "ConfirmSpawn";
        Invoke(CONFIRM_SPAWN,0.5f);

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
                _selfRender.material.color = new Color(171f / 255f, 116f / 255f, 64f / 255f);
                break;
            case Currency.CurrencyType.silver:
                _selfRender.material.color = new Color(192 / 255f, 192 / 255f, 192 / 255f);
                break;
            case Currency.CurrencyType.gold:
                _selfRender.material.color = new Color(255 / 255f, 215 / 255f, 0 / 255f);
                break;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag != "Coin" && _hasSpawned)
        {
            if (!_hasPlayed)
            {
                _coinPatch.Play(_coinSource);
                _hasPlayed = true;
                Destroy(gameObject.transform.parent.gameObject, 2);
            }

    }


    }

    private void ConfirmSpawn()
    {
        _hasSpawned = true;
    }

}
