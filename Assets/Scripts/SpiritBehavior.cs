using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBehavior : MonoBehaviour
{
    private Transform customTransform;

    private float speed = 3.0f;

    void Start()
    {
        customTransform = GetComponent<Transform>();
    }

    void Update()
    {
        customTransform.position = Vector3.MoveTowards(customTransform.position, new Vector3(customTransform.position.x, 100, 0), speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
