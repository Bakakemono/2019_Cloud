using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitShow : MonoBehaviour
{
    [SerializeField] Vector2[] limit = new Vector2[4];

    [SerializeField] private bool show = true;
    void OnDrawGizmos()
    {
        if (!show)
            return;

        Gizmos.color = Color.blue;

        Gizmos.DrawLine(limit[0], limit[1]);
        Gizmos.DrawLine(limit[1], limit[2]);
        Gizmos.DrawLine(limit[2], limit[3]);
        Gizmos.DrawLine(limit[3], limit[0]);
        

    }

}
