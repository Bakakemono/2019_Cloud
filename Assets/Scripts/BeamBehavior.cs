using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehavior : MonoBehaviour
{
    private float nmb = 0;
    private SpriteRenderer spriteRenderer;
    private Transform customTransform;

    private float speed = 50.0f;
    private float speedApparition = 3.0f;
    private float speedFadeOut = 1.0f;
    private int stayTime = 100;
    private int stayCount = 0;

    private float landingTime = 0.0f;

    private float targetScale = 0.6f;

    private bool isArrived = false;
    private bool isBeamed = false;

    [SerializeField] private SpriteRenderer BeamLandingBoomRenderer;
    [SerializeField] private SpriteRenderer frontBeam;

    [SerializeField] private AnimationCurve curveBeam;
    [SerializeField] private AnimationCurve beamFadeOut;

    private PraiseTheSunBehavior solaire;

    [SerializeField] private Collider2D damageArea;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        customTransform = GetComponent<Transform>();
        customTransform.localScale = new Vector3(curveBeam.Evaluate(0) * targetScale, customTransform.localScale.y);
        
    }

    void Update()
    {
        landingTime += Time.deltaTime;

        if (!isArrived)
        {
            customTransform.position = Vector3.MoveTowards(customTransform.position,
                new Vector3(customTransform.position.x, -100), speed * Time.deltaTime);
        }

        if (isArrived && !isBeamed)
        {
            customTransform.localScale = new Vector2(curveBeam.Evaluate(landingTime) * targetScale, 1);



            if (curveBeam.Evaluate(landingTime) >= 1)
            {
                damageArea.enabled = true;
                isBeamed = true;
                landingTime = 0;
            }
        }


        if (isBeamed)
        {
            Color color = BeamLandingBoomRenderer.color;
            color.a = color.a * beamFadeOut.Evaluate(landingTime);
            BeamLandingBoomRenderer.color = color;

            Color color2 = spriteRenderer.color;
            color2.a = color.a * beamFadeOut.Evaluate(landingTime);
            spriteRenderer.color = color2;

            Color color3 = frontBeam.color;
            color3.a = color.a * beamFadeOut.Evaluate(landingTime);
            frontBeam.color = color3;
        }

        if (spriteRenderer.color.a <= 0.2f)
        {
            damageArea.enabled = false;
        }

        if (spriteRenderer.color.a <= 0)
        {
            solaire.BackToWalk();
            Destroy(gameObject);
        }
        
    }

    public void GetPraiseTheSunBehavior(PraiseTheSunBehavior solaire)
    {
        this.solaire = solaire;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Ground")
        {
            isArrived = true;
            landingTime = 0;
        }
    }


}
