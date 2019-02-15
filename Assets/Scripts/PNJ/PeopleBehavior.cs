using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehavior : MonoBehaviour
{
    private Transform customTransform;
    private SpriteRenderer spriteRenderer;

    [SerializeField] public float speed = 1.0f;

    [SerializeField] private Vector2 left = new Vector2(-10, -4);
    [SerializeField] private Vector2 right = new Vector2(10, -4);

    public bool goRight = false;

    void Start()
    {
        customTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (goRight)
        {
            spriteRenderer.flipX = true;
            customTransform.position = Vector3.MoveTowards(customTransform.position, right, speed * Time.deltaTime);
        }

        else
        {
            spriteRenderer.flipX = false;
            customTransform.position = Vector3.MoveTowards(customTransform.position, left, speed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawSphere(left, 0.2f);
        Gizmos.DrawSphere(right, 0.2f);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(left, right);

    }
}
