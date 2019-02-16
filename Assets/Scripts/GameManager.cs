using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image dropBare;

    [SerializeField] private Image specialDropBare;

    [SerializeField] private RainBlaster rainBlaster;

    void Update()
    {
        dropBare.fillAmount = (rainBlaster.currentBasicDropInventory / rainBlaster.MAX_BASIC_DROP_CAPACITY);
    }
}
