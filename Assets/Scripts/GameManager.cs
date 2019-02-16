using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public void ScoreUp(int score)
    {
        scoreCount += score;
    }
}
