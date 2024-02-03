using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Unity

public class TargetManager : MonoBehaviour
{
    [Header("Target1")]
    public Transform target1Transform;
    public Rigidbody target1Rigidbody;

    [Header("Target2")]
    public Transform target2Transform;
    public Rigidbody target2Rigidbody;

    [Header("Target3")]
    public Transform target3Transform;
    public Rigidbody target3Rigidbody;

    public Vector3 originalTarget1Position;
    public Quaternion originalTarget1Rotation;

    public Vector3 originalTarget2Position;
    public Quaternion originalTarget2Rotation;

    public Vector3 originalTarget3Position;
    public Quaternion originalTarget3Rotation;

    GameObject target1;
    GameObject target2;
    GameObject target3;

    void Start()
    {
        target1 = GameObject.FindWithTag("target1");
        target2 = GameObject.FindWithTag("target2");
        target3 = GameObject.FindWithTag("target3");
    }
    private void OnCollisionEnter(Collision targets)
    {
        if (targets.gameObject.tag == "target1")
        {
            target1Rigidbody.isKinematic = false;
        }
        else if (targets.gameObject.tag == "target2")
        {
            target2Rigidbody.isKinematic = false;
        }
        else if (targets.gameObject.tag == "target3")
        {
            target3Rigidbody.isKinematic = false;
        }
    }
}




