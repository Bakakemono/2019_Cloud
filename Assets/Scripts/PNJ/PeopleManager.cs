using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    #region Gizmos
    [SerializeField] private Vector2 left = new Vector2(-10, -4);
    [SerializeField] private Vector2 right = new Vector2(10, -4);
    #endregion

    [SerializeField] private GameObject Peon;
    [SerializeField] private GameObject PraiseTheSun;




    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawWireSphere(left, 0.2f);
        Gizmos.DrawWireSphere(right, 0.2f);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(left, right);

    }

}
