using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image normaldropBare;

    [SerializeField] private Image beerDropBar;

    [SerializeField] private Image oliveOilDropBar;

    [SerializeField] private Image lemonJuiceDropBar;


    [SerializeField] private RainBlaster rainBlaster;

    [SerializeField] private Text score;

    private int scoreCount = 0;

    void Update()
    {
        normaldropBare.fillAmount = (rainBlaster.currentBasicDropInventory / rainBlaster.MAX_BASIC_DROP_CAPACITY);
        score.text = scoreCount.ToString();

        if (rainBlaster.isReloading)
        {
            normaldropBare.color = Color.grey;
        }
        else
        {
            normaldropBare.color = Color.white;
        }

        if (rainBlaster.powerUp != RainBlaster.PowerUp.NONE)
        {
            switch (rainBlaster.powerUp)
            {
                case RainBlaster.PowerUp.LEMON:
                    lemonJuiceDropBar.fillAmount = Mathf.MoveTowards(lemonJuiceDropBar.fillAmount, (rainBlaster.currentPowerupDropInventory / rainBlaster.MAX_POWERUP_DROP_CAPACITY), 0.1f);
                    break;
                case RainBlaster.PowerUp.BEER:
                    beerDropBar.fillAmount =
                        (rainBlaster.currentPowerupDropInventory / rainBlaster.MAX_POWERUP_DROP_CAPACITY);
                    break;
                case RainBlaster.PowerUp.OIL:
                    oliveOilDropBar.fillAmount =
                        (rainBlaster.currentPowerupDropInventory / rainBlaster.MAX_POWERUP_DROP_CAPACITY);
                    break;
            }
        }
        else
        {
            lemonJuiceDropBar.fillAmount = 0;
            beerDropBar.fillAmount = 0;
            oliveOilDropBar.fillAmount = 0;
        }

    }

    public void ScoreUp(int score)
    {
        scoreCount += score;
    }
}
