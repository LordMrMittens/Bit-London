using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject guiObject;
    public string levelToLoad;
    //[SerializeField] bool goesToGroundFloor;

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
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {           
                Application.LoadLevel(levelToLoad);

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        guiObject.SetActive(false);
    }
}
