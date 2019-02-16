using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Peon;
    [SerializeField] private GameObject Solaire;
    [SerializeField] private GameObject[] PraiseTheSunBeliever;
    private float high = -3.521f;

    private float time = 0;
    void Start()
    {
        StartCoroutine(WaitPeon());
        
    }

    IEnumerator WaitPeon()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.6f + 1f * Random.value);
            SpawnPeon();
            time += Time.deltaTime * 10;
        }
    }

    void SpawnPeon()
    {
        int randy = Random.Range(0, 100);
        float rando = Random.value;

        if (randy < 2 + time / 10)
        {
            if (FindObjectOfType<PraiseTheSunBehavior>() == null)
            {
                GameObject peon = Instantiate(Solaire, new Vector3(rando <= 0.5f ? -10 : 10, high, 0),
                    Quaternion.identity);

                peon.GetComponent<PraiseTheSunBehavior>().GetTarget(rando <= 0.5f ? true : false);
            }
            else
            {
                SpawnPeon();
            }
        }
        else if (randy < 8 + time)
        {
            GameObject peon = Instantiate(PraiseTheSunBeliever[Random.Range(0, PraiseTheSunBeliever.Length)], new Vector3(rando <= 0.5f ? -10 : 10, high, 0),
                Quaternion.identity);
            peon.GetComponent<PraiseTheSonAdepteBehavior>().GetTarget(rando <= 0.5f ? true : false);
        }
        else
        {
            GameObject peon = Instantiate(Peon[Random.Range(0, Peon.Length)], new Vector3(rando <= 0.5f ? -10 : 10, high , 0),
                Quaternion.identity);
            peon.GetComponent<PeopleBehavior>().GetTarget(rando <= 0.5f ? true : false);
        }

    }
}
