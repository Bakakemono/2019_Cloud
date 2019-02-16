using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehavior : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private bool stop = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (stop)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            rigidbody2D.velocity = new Vector2(0, 0);

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void LetsDestroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            stop = true;
            animator.SetTrigger("Plok");
        }
    }
}
