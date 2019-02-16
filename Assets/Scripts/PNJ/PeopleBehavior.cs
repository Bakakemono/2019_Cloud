using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehavior : MonoBehaviour
{
    private Transform customTransform;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;

    [SerializeField] public float speed = 1.0f;

    private float high = -3.521f;
    private Vector2 left;
    private Vector2 right;

    [SerializeField] private GameObject spirit;

    public bool goRight = false;

    void Start()
    {
        left = new Vector2(-10, high);
        right = new Vector2(10, high);
        customTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
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
        if (collider2D.tag == "Drop")
        {
            if (collider2D.GetComponent<DropBehavior>().dropType == DropBehavior.DropType.OIL)
            {
                speed *= 3;
                gameManager.ScoreUp(500);
            }
            else
            {
                Hit();
                Destroy(collider2D);
            }
        }
    }

    public void GetTarget(bool goRight)
    {
        this.goRight = goRight;
    }

    void Hit()
    {
        gameManager.ScoreUp(100);
        Instantiate(spirit, customTransform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    
}
