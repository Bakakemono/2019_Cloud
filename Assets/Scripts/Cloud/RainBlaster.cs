using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RainBlaster : MonoBehaviour
{
    [SerializeField] private GameObject basicDrop;
    private Transform customTransform;

    private int coolDown = 0;
    [SerializeField] private float dropRate = 50;
    
    private const int FRAME_RATE = 50;

    private bool isRecovery = false;

    private bool isReloading = false;

    private int reload = 0;

    private int reloadGoal = 5;

    private float range = 3;

    public float MAX_BASIC_DROP_CAPACITY = 100;

    public float currentBasicDropInventory;


    void Start()
    {
        customTransform = GetComponent<Transform>();
        currentBasicDropInventory = MAX_BASIC_DROP_CAPACITY;
    }

    void Update()
    {
        if (!isRecovery && !isReloading)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject newDrop = Instantiate(basicDrop,new Vector3((range * Random.value + customTransform.position.x) - range / 2, customTransform.position.y, 0), Quaternion.identity);
                newDrop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
                currentBasicDropInventory--;
                isRecovery = true;

                if (currentBasicDropInventory <= 0)
                {
                    isReloading = true;
                }
            }
        }

        reload++;

        if (currentBasicDropInventory < MAX_BASIC_DROP_CAPACITY && reload >= reloadGoal)
        {
            currentBasicDropInventory++;
            
            reload = 0;
        }

        if (isReloading && currentBasicDropInventory >= MAX_BASIC_DROP_CAPACITY / 2)
        {
            isReloading = false;
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
