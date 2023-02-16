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
        Vector3 eulersAngle = new Vector3(0, 30 * Time.deltaTime, 0);
        gameObject.transform.Rotate(eulersAngle, Space.World);
       //float something = 90 * Time.deltaTime;
       //    Vector3 testRotation = Quaternion.Euler(0, something, 0) * new Vector3(0f, 1f, 0f).normalized; ;
       //    var actualRotation = Quaternion.LookRotation(testRotation, Vector3.up);
       //    transform.rotation = actualRotation;
    }
}
