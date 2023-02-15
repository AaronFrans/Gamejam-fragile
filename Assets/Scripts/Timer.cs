using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text = null;

    [SerializeField]
    private float _secondsUntilEnd = 0;

    private bool _hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (_text == null)
            Debug.Log("no _text set");

        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartTimer();
        }

        if (_hasStarted)
        {
            _secondsUntilEnd -= Time.deltaTime;
            UpdateText();
        }
    }

    private void UpdateText()
    {

        TimeSpan time = TimeSpan.FromSeconds(_secondsUntilEnd);
        _text.text = time.ToString("mm\\:ss");
    }

    public void StartTimer()
    {
        _hasStarted = true;
    }
}
