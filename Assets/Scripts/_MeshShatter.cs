using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MeshShatter : MonoBehaviour
{

    public GameObject _meshShattered;

    public void ShatterMesh(Color color)
    {
        var instantiated = Instantiate(_meshShattered, transform.position, transform.rotation);

        foreach (var item in instantiated.GetComponentsInChildren<MeshRenderer>())
        {
            item.material.color = color;
        }
        Destroy(gameObject);
    }
}
