using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RainBlaster : MonoBehaviour
{
    [SerializeField] private GameObject basicDrop;
    private Transform customTransform;

    private int coolDown = 0;
    [SerializeField] private float dropRate = 5;
    
    private const int FRAME_RATE = 50;

    private bool isRecovery = false;

    private float range = 3;

    void Start()
    {
        customTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (!isRecovery)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject newDrop = Instantiate(basicDrop,new Vector3((range * Random.value + customTransform.position.x) - range / 2, customTransform.position.y, 0), Quaternion.identity);
                newDrop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
                isRecovery = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isRecovery)
        {
            coolDown++;
            if (coolDown >= FRAME_RATE / dropRate)
            {
                coolDown = 0;
                isRecovery = false;
            }
        }
    }
}
