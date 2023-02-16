using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class _rotateCamera : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 eulersAngle = new Vector3(0, 10 * Time.deltaTime, 0);
        gameObject.transform.Rotate(eulersAngle, Space.World);
      
    }
}
