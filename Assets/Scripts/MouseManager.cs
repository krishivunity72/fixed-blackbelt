using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;

    [Header("Axe")]
    public Transform axeTransform;
    public Rigidbody axeRigidbody;


    public Vector3 orignalAxePosition;
    public Quaternion originalAxeRotation;


    // Start is called before the first frame update
    void Start()
    {
        orignalAxePosition = axeTransform.position;
        originalAxeRotation = axeTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x,
                mouseDifference.y * -1.2f,
                (mouseDifference.y) * 1.5f
            );

            axeTransform.position = orignalAxePosition - launchVector / 500;
            launchVector.Normalize();

        }

        if (Input.GetMouseButtonUp(0))
        {
            axeRigidbody.isKinematic = false;
            transform.Rotate(Vector3.forward, Time.deltaTime * 500f);
            axeRigidbody.AddForce(launchVector * launchForce, ForceMode.Impulse);
            
        }

        if (Input.GetKey("space"))
        {
            axeRigidbody.isKinematic = true;
            axeTransform.position = orignalAxePosition;
            axeTransform.rotation = originalAxeRotation;
        }

        //transform.Rotate(Vector3.forward, Time.deltaTime * -500f);
    }
}
