using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image dropBare;

    [SerializeField] private Image specialDropBare;

    [SerializeField] private Sprite beerDropBar;

    [SerializeField] private Sprite OliveOilDropBar;

    [SerializeField] private Sprite LemonJuiceDropBar;


    [SerializeField] private RainBlaster rainBlaster;

    [SerializeField] private Text score;

    private int scoreCount = 0;

    void Update()
    {
        dropBare.fillAmount = (rainBlaster.currentBasicDropInventory / rainBlaster.MAX_BASIC_DROP_CAPACITY);
        score.text = scoreCount.ToString();

        if (rainBlaster.isReloading)
        {
            dropBare.color = Color.grey;
        }
        else
        {
            dropBare.color = Color.white;
        }

        if (rainBlaster.powerUp != RainBlaster.PowerUp.NONE)
        {
            specialDropBare.enabled = true;
            switch (rainBlaster.powerUp)
            {
                case RainBlaster.PowerUp.LEMON:
                    specialDropBare.sprite = LemonJuiceDropBar;
                    break;
                case RainBlaster.PowerUp.BEER:
                    specialDropBare.sprite = beerDropBar;
                    break;
                case RainBlaster.PowerUp.OIL:
                    specialDropBare.sprite = OliveOilDropBar;
                    break;
            }

            specialDropBare.fillAmount =
                (rainBlaster.currentPowerupDropInventory / rainBlaster.MAX_POWERUP_DROP_CAPACITY);
        }
        else
        {
            specialDropBare.enabled = false;
        }

    }

    public void ScoreUp(int score)
    {
        scoreCount += score;
    }
}
