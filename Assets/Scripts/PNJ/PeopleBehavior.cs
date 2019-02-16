using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehavior : MonoBehaviour
{
    private Transform customTransform;
    private SpriteRenderer spriteRenderer;

    [SerializeField] public float speed = 1.0f;

    private Vector2 left = new Vector2(-10, -3.77f);
    private Vector2 right = new Vector2(10, -3.77f);

    

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

            if (Vector2.Distance(customTransform.position, right) < 0.1f)
                Destroy(gameObject);
        }

        else
        {
            spriteRenderer.flipX = false;
            customTransform.position = Vector3.MoveTowards(customTransform.position, left, speed * Time.deltaTime);

            if (Vector2.Distance(customTransform.position, left) < 0.1f)
                Destroy(gameObject);    
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Drop")
            Hit();
    }

    public void GetTarget(bool goRight)
    {
        this.goRight = goRight;
    }

    void Hit()
    {
        Debug.Log("ail");
    }
    
}
