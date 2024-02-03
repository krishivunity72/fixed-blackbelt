using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Unity

public class ScoreManager : MonoBehaviour
{
    [Header("Stuff")]
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject Cube;
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Axehead;
    public GameObject Axepommel;

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
    //public GameObject box;
    GameObject target1;
    GameObject target2;
    GameObject target3;
    public GameObject title;
    private int score = 0;
    private int rebirth = 0;


    void Start()
    {
        target1 = GameObject.FindWithTag("target1");
        target2 = GameObject.FindWithTag("target2");
        target3 = GameObject.FindWithTag("target3");
        title.SetActive(true);

        originalTarget1Position = target1Transform.position;
        originalTarget1Rotation = target1Transform.rotation;

        originalTarget2Position = target2Transform.position;
        originalTarget2Rotation = target2Transform.rotation;

        originalTarget3Position = target3Transform.position;
        originalTarget3Rotation = target3Transform.rotation;
    }
    void Update()
    {
        if(Input.anyKeyDown)
        {
            title.SetActive(false);
        }
        if(score == 50)
        {
            score = 0;
            //rebirth++;
            //GameObject rebirthText = GameObject.Find("Rebirth");
            //rebirthText.GetComponent<Text>().text = rebirth.ToString();
            title.SetActive(true);
            //GameObject objects = GameObject.Find("objects");
            //objects.transform.position +=  new Vector3(0,0,-10.0f);
            originalTarget1Position+= new Vector3(0,0,-10.0f);
            originalTarget2Position+= new Vector3(0,0,-10.0f);
            originalTarget3Position+= new Vector3(0,0,-10.0f);
        } 
    }
    
    
private void OnCollisionEnter(Collision targets)
{
    bool collided = false;
    if (targets.gameObject.tag == "target1")
    {
        target1Transform.position = originalTarget1Position;
        target1Transform.rotation = originalTarget1Rotation;
        target1Rigidbody.isKinematic = true;

        score++; // Increment the score by 1

        // Update the score UI (if you have a UI element to display the score)
        GameObject scoreText = GameObject.Find("Score");
        scoreText.GetComponent<Text>().text = score.ToString();
            collided = true;
    }
    else if (targets.gameObject.tag == "target2")
    {
        target2Transform.position = originalTarget2Position;
        target2Transform.rotation = originalTarget2Rotation;
        target2Rigidbody.isKinematic = true;

        score++; // Increment the score by 1
        Debug.Log(rebirth);
        // Update the score UI (if you have a UI element to display the score)
        GameObject scoreText = GameObject.Find("Score");
        scoreText.GetComponent<Text>().text = score.ToString();
                        collided = true;
    }
    else if (targets.gameObject.tag == "target3")
    {
        target3Transform.position = originalTarget3Position;
        target3Transform.rotation = originalTarget3Rotation;
        target3Rigidbody.isKinematic = true;

        score++; // Increment the score by 1

        // Update the score UI (if you have a UI element to display the score)
        GameObject scoreText = GameObject.Find("Score");
        scoreText.GetComponent<Text>().text = score.ToString();
            collided = true;
        }
    if (score % 5 == 0 && collided) {
            target1Transform.localScale *= 0.75f;
            target2Transform.localScale *= 0.75f;
            target3Transform.localScale *= 0.75f;
            
        }
        if (score % 3 == 0 && collided) {
            GameObject duplicate = Instantiate(Cube, (new Vector3(Random.Range(-60f, 60f), Random.Range(0, 80f), -70)), Quaternion.identity);
        }
        if (score % 4 == 0 && collided)
        {
            GameObject duplicate = Instantiate(Cube1, (new Vector3(Random.Range(-60f, 60f), Random.Range(0, 80f), -70)), Quaternion.identity);
        }
        if (score % 5 == 0 && collided)
        {
            GameObject duplicate = Instantiate(Cube2, (new Vector3(Random.Range(-60f, 60f), Random.Range(0, 80f), -70)), Quaternion.identity);
        }

        if (collided) {
            floor1.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            floor2.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            floor3.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            floor4.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Cube1.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Cube2.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Axehead.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Axepommel.GetComponent<Renderer>().material.color = Axehead.GetComponent<Renderer>().material.color;
        }
    
}
}

