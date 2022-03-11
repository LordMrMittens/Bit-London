using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setactivate : MonoBehaviour
{
    public GameObject guiObject;

    void Start()
    {
        guiObject.SetActive(false);
    }


    //This is for UI text when we enter the Level object we will see the UI element
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        guiObject.SetActive(false);
    }
}
