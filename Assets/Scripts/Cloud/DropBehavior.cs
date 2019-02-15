using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehavior : MonoBehaviour
{

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
