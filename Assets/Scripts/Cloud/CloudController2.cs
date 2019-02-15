using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController2 : MonoBehaviour
{
    #region Reference Component

    private Transform customTransform;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    #endregion

    #region Stat cloud

    [SerializeField] private Vector2 playerForce = new Vector2(1, 1);
    private Vector2 input = new Vector2(0, 0);

    [SerializeField] private Vector2 baseMaxSpeed = new Vector2(1, 1);
    private Vector2 maxSpeed = new Vector2(1, 1);
    [SerializeField] private Vector2 slow = new Vector2(0, 0);

    #endregion


    void Start()
    {
        customTransform = GetComponent<Transform>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxSpeed = baseMaxSpeed;
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if(input.x < 0.5f)
            rigidBody2D.AddForce(input * 0.5f * playerForce);
        else
            rigidBody2D.AddForce(input * playerForce);

        CapSpeed();
        Slow();
    }

    private void CapSpeed()
    {
        Vector2 actualSpeed = rigidBody2D.velocity;
        bool xChange = false;
        bool yChange = false;

        if (actualSpeed.x >= maxSpeed.x)
        {
            actualSpeed.x = maxSpeed.x;
            xChange = true;
        }
        else if (actualSpeed.x <= -maxSpeed.x)
        {
            actualSpeed.x = -maxSpeed.x;
            xChange = true;
        }

        if (actualSpeed.y >= maxSpeed.y)
        {
            actualSpeed.y = maxSpeed.y;
            yChange = true;
        }
        else if (actualSpeed.y <= -maxSpeed.y)
        {
            actualSpeed.y = -maxSpeed.y;
            yChange = true;
        }

        if (xChange)
            maxSpeed.x = maxSpeed.x * 1.5f;
        else
            maxSpeed.x = baseMaxSpeed.x;

        if (yChange)
            maxSpeed.y = maxSpeed.y * 1.5f;
        else
            maxSpeed.y = baseMaxSpeed.y;


        rigidBody2D.velocity = actualSpeed;
    }

    private void Slow()
    {
        Vector2 actualSpeed = rigidBody2D.velocity;
        if (input.x == 0)
        {
            actualSpeed.x = Mathf.Lerp(actualSpeed.x, 0, slow.x / 100);
        }

        if (input.y == 0)
        {
            actualSpeed.y = Mathf.Lerp(actualSpeed.y, 0, slow.y / 100);
        }

        rigidBody2D.velocity = actualSpeed;
    }

}
