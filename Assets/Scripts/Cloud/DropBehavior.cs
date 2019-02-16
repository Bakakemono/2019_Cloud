using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehavior : MonoBehaviour
{

    public enum DropType
    {
        BASIC,
        BEER,
        OIL,
        LEMON
    }

    public DropType dropType = DropType.BASIC;

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
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            stop = false;
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
