using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehavior : MonoBehaviour
{
    private Transform customTransform;

    [SerializeField] private float speed = 1.0f;

    [SerializeField] private Vector2 left = new Vector2(-10, -4);
    [SerializeField] private Vector2 right = new Vector2(10, -4);

    public bool goRight = false;

    void Start()
    {
        customTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (goRight)
            customTransform.position = Vector3.MoveTowards(customTransform.position, right, speed);
        else
            customTransform.position = Vector3.MoveTowards(customTransform.position, left, speed);

    }
}
