using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CollisionDelete : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Coin")
            Destroy(gameObject, 1f);
    }
}
