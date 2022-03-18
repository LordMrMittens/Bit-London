using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Camera orthographicCamera;

    public Transform followTransform;
    public Transform cameraTransform;

    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    //public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    //public Vector3 newZoom;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        newPosition = transform.position;
        newRotation = transform.rotation;
        //newZoom = cameraTransform.localPosition;
        orthographicCamera.orthographicSize = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followTransform.position;

        HandleMouseInput();
        HandleMovementInput();
    }

    void HandleMouseInput()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            orthographicCamera.orthographicSize = orthographicCamera.orthographicSize + 1000 * Time.deltaTime; //1000 = speed 
            if (orthographicCamera.orthographicSize > 40)
            {
                orthographicCamera.orthographicSize = 40; // Max size
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            orthographicCamera.orthographicSize = orthographicCamera.orthographicSize - 1000 * Time.deltaTime;
            if (orthographicCamera.orthographicSize < 10)
            {
                orthographicCamera.orthographicSize = 10; // Min size
            }
        }
    }

    void HandleMovementInput()
    {
        /*if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        */
        if (Input.GetKeyDown(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(new Vector3(0f, 45f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(new Vector3(0f, -45f, 0f));
        }

        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        transform.rotation = newRotation;
        //cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }
}
