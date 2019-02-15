using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PraiseTheSunBehavior : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector2 target = new Vector2(0, -4);
    private Vector2 left = new Vector2(-10, -4);
    private Vector2 right = new Vector2(-10, -4);

    public bool goRight = false;
    private bool isMoving = true;
    private bool isFiring = false;
    [SerializeField] private Transform customTransform;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject SunBeam;

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
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if(Vector2.Distance(customTransform.position, target) > 0.1f)
            customTransform.position = Vector3.MoveTowards(customTransform.position, target, speed * Time.deltaTime);
        else if (!isFiring)
        {
            TimeToSunYourLovelyFace();
        }

    }

    private void TimeToSunYourLovelyFace()
    {
        Instantiate(SunBeam);
    }
}
