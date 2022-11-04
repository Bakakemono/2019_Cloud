using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnimation : MonoBehaviour
{
    private Transform customTransform;
    private Rigidbody2D rigidbody2D;

    private Vector2 beginPosition;

    private int range = 20;


    void Start()
    {
        customTransform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        beginPosition = customTransform.position;
    }

    void OnBecameInvisible()
    {
        customTransform.position = new Vector3(Random.Range(beginPosition.x - range, beginPosition.x + range), beginPosition.y);
        rigidbody2D.velocity = Vector2.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector3(beginPosition.x - range, beginPosition.y), new Vector3(beginPosition.x + range, beginPosition.y));
    }
}
