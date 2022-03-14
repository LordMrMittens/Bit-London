using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpeechBalloon : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Image FG;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = (target.position - Camera.main.transform.position).normalized;
        bool isBehind = Vector3.Dot(direction, Camera.main.transform.forward) <= 0.0f;
        FG.enabled = !isBehind;

        transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }
}
