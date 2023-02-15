using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class _rotateCamera : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {

            float something = 1 * Time.deltaTime;
            Vector3 testRotation = Quaternion.Euler(0, something, 0) * new Vector3(0f, 1f, 0f).normalized; ;
            var actualRotation = Quaternion.LookRotation(testRotation, Vector3.up);
            transform.rotation = actualRotation;
    }
}
