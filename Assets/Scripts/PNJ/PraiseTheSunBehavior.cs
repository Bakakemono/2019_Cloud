using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PraiseTheSunBehavior : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector2 target = new Vector2(0, -3.77f);
    private Vector2 left = new Vector2(-10, -3.77f);
    private Vector2 right = new Vector2(10, -3.77f);

    public bool goRight = false;
    private bool isMoving = true;
    private bool isFiring = false;
    private bool isPostBeam = false;
    private Transform customTransform;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject SunBeam;

    private Animator animator;

    void Start()
    {
        customTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

        if (Vector2.Distance(customTransform.position, target) > 0.1f && !isPostBeam)
        {
            customTransform.position = Vector3.MoveTowards(customTransform.position, (Vector3)target, speed * Time.deltaTime);
        }
        else if (!isFiring)
        {
            animator.SetTrigger("PrepareToPraise");
            StartCoroutine(PrepareToPreise());
            isFiring = true;
        }

        if (isPostBeam)
        {
            if (goRight)
            {
                customTransform.position = Vector3.MoveTowards(customTransform.position, (Vector3)right, speed * Time.deltaTime);

                if (Vector2.Distance(customTransform.position, right) < 0.1f)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                customTransform.position = Vector3.MoveTowards(customTransform.position, (Vector3)left, speed * Time.deltaTime);

                if (Vector2.Distance(customTransform.position, left) < 0.1f)
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    private IEnumerator PrepareToPreise()
    {
        yield return new WaitForSeconds(1);
        animator.ResetTrigger("PrepareToPraise");
        animator.SetTrigger("Praise");
        TimeToSunYourLovelyFace();
    }

    private void TimeToSunYourLovelyFace()
    {
        GameObject solarBeam = Instantiate(SunBeam, new Vector3(customTransform.position.x, 20, 0), Quaternion.identity);
        solarBeam.GetComponent<BeamBehavior>().GetPraiseTheSunBehavior(this);
    }

    public void BackToWalk()
    {
        animator.SetTrigger("BackToWalk");
        isPostBeam = true;
    }

    public void GetTarget(bool goRight)
    {
        this.goRight = goRight;

        target = new Vector2(Random.Range(-8, 8), target.y);
    }

}
