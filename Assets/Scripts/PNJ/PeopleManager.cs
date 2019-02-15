using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    [SerializeField] private Vector2 left = new Vector2(-10, -4);
    [SerializeField] private Vector2 right = new Vector2(10, -4);

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawSphere(left, 0.2f);
        Gizmos.DrawSphere(right, 0.2f);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(left, right);

    }

}
