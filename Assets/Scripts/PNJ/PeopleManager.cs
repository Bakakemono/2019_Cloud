using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    [SerializeField] private GameObject Peon;
    [SerializeField] private GameObject Solaire;
    [SerializeField] private GameObject PraiseTheSunBeliever;

    void Start()
    {
        StartCoroutine(WaitPeon());
    }

    IEnumerator WaitPeon()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(0.1f + 0.8f * Random.value);
            SpawnPeon();
        }
    }

    void SpawnPeon()
    {
        int randy = Random.Range(0, 100);
        float rando = Random.value;
        if (randy < 20)
        {
            if (FindObjectOfType<PraiseTheSunBehavior>() == null)
            {
                GameObject peon = Instantiate(Solaire, new Vector3(rando <= 0.5f ? -10 : 10, -3.77f, 0),
                    Quaternion.identity);

                peon.GetComponent<PraiseTheSunBehavior>().GetTarget(rando <= 0.5f ? true : false);
            }
        }
        else if (randy < 35)
        {
            //GameObject peon = Instantiate(PraiseTheSunBeliever, new Vector3(rando <= 0.5f ? -10 : 10, -3.77f, 0),
            //    Quaternion.identity);
            //peon.GetComponent<PeopleBehavior>().GetTarget(rando <= 0.5f ? true : false);
            Debug.Log("POP PEON AMELIOREEEEEEE");
        }
        else
        {
            GameObject peon = Instantiate(Peon, new Vector3(rando <= 0.5f ? -10 : 10, -3.77f, 0),
                Quaternion.identity);
            peon.GetComponent<PeopleBehavior>().GetTarget(rando <= 0.5f ? true : false);
        }

    }
}
