using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RainBlaster : MonoBehaviour
{
    public enum PowerUp
    {
        OIL,
        BEER,
        LEMON,
        NONE
    }

    public PowerUp powerUp = PowerUp.NONE;

    [SerializeField] private GameObject basicDrop;
    [SerializeField] private GameObject lemonDrop;
    [SerializeField] private GameObject oilDrop;
    [SerializeField] private GameObject beerDrop;

    private Transform customTransform;

    private int coolDown = 0;
    [SerializeField] private float dropRate = 50;
    
    private const int FRAME_RATE = 50;

    private bool isRecovery = false;

    public bool isReloading = false;

    private int reload = 0;

    private int reloadGoal = 5;

    private float range = 3;

    public float MAX_BASIC_DROP_CAPACITY = 100;

    public float currentBasicDropInventory;

    public float MAX_POWERUP_DROP_CAPACITY = 50;

    public float currentPowerupDropInventory;

    private float powerUpDropRate = 1.0f;

    private bool isPowerUp = false;
    private bool gotAnewOne = false;

    private bool isRecoveryPowerUp = false;
    private int powerUpCoolDown = 0;

    private int powerUpRange = 0;

    private PowerUp previousStat = PowerUp.NONE;


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

        FirePowerUpDrop();

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

        if (isRecoveryPowerUp)
        {
            powerUpCoolDown++;
            if (powerUpCoolDown >= FRAME_RATE / powerUpDropRate)
            {
                powerUpCoolDown = 0;
                isRecoveryPowerUp = false;
            }
        }
    }

    private void FirePowerUpDrop()
    {
        if(powerUp == PowerUp.NONE)
            return;

        GameObject DropToSpawn = new GameObject();
        switch (powerUp)
        {
            case PowerUp.LEMON:
                DropToSpawn = lemonDrop;
                break;

            case PowerUp.BEER:
                DropToSpawn = beerDrop;
                break;

            case PowerUp.OIL:
                DropToSpawn = oilDrop;
                break;
        }


        if (!isRecoveryPowerUp)
        {
            if (Input.GetButton("Fire2"))
            {
                GameObject newDrop = Instantiate(DropToSpawn, new Vector3((powerUpRange * Random.value + customTransform.position.x) - powerUpRange / 2, customTransform.position.y, 0), Quaternion.identity);
                newDrop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
                currentPowerupDropInventory--;
                isRecoveryPowerUp = true;

                if (currentPowerupDropInventory <= 0)
                {
                    isPowerUp = false;
                }
            }
        }

        if (!isPowerUp)
            powerUp = PowerUp.NONE;
    }


    private void SetupPowerUp()
    {
        switch (powerUp)
        {
            case PowerUp.LEMON:
                powerUpDropRate = 10.0f;
                MAX_POWERUP_DROP_CAPACITY = 50.0f;
                powerUpRange = 4;
                break;

            case PowerUp.BEER:
                powerUpDropRate = 50;
                MAX_POWERUP_DROP_CAPACITY = 500;
                powerUpRange = 8;
                break;

            case PowerUp.OIL:
                powerUpDropRate = 5;
                MAX_POWERUP_DROP_CAPACITY = 40;
                powerUpRange = 8;
                break;
        }

        if (gotAnewOne)
        {
            gotAnewOne = false;
            currentPowerupDropInventory = MAX_POWERUP_DROP_CAPACITY;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LemonSpirit")
        {
            Destroy(col.gameObject);
            previousStat = powerUp;
            powerUp = PowerUp.LEMON;
            isPowerUp = true;

            gotAnewOne = true;
            SetupPowerUp();
        }
        
    }

}
