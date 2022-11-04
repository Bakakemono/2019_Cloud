using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LogoCloud : MonoBehaviour
{
    private Transform customTransform;

    [SerializeField] private AnimationCurve floatingAnimation;


    private Vector2 startPosition;
    void Start()
    {
        customTransform = GetComponent<Transform>();
        startPosition = customTransform.position;
    }

    void Update()
    {
        customTransform.position = startPosition + new Vector2(0, floatingAnimation.Evaluate(Time.time) * 1000 * Time.deltaTime);
        Debug.Log(customTransform.position);
    }
}
