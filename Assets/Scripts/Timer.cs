using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text = null;

    [SerializeField]
    private Currency _currency = null;

    [SerializeField]
    private float _secondsUntilEnd = 0;

    static public bool _hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (_text == null)
            Debug.Log("no _text set");
        if (_currency == null)
            Debug.Log("no _currency set");
        _hasStarted = false;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

        if (_hasStarted)
        {
            _secondsUntilEnd -= Time.deltaTime;
            if (_secondsUntilEnd < 0)
            {
                Currency.TotalCurrency += _currency.currency;
                SceneManager.LoadScene("ShopScene");
            }
            UpdateText();
        }
    }

    private void UpdateText()
    {

        TimeSpan time = TimeSpan.FromSeconds(_secondsUntilEnd);
        _text.text = time.ToString("mm\\:ss");
    }
}
