using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.VFX;

public class Thunder : MonoBehaviour
{
    public GameObject ball;
    private Vector3 origin_pos;
    private Quaternion origin_rot;
    public float speed = 500f;
    public Camera cam;
    private bool hit = false;
    private bool fly = false;
    private float start_time = 0;
    public float disappearTime = 1.0f;
    private GameObject smoke;
    public VisualEffect thunder;

    // Start is called before the first frame update
    void Start()
    {
        smoke = GameObject.FindGameObjectWithTag("Smoke1");
        //smoke.GetComponent<Renderer>().enabled = false;
        origin_pos = transform.localPosition;
        origin_rot = transform.localRotation;
    }

    // Update is called once per frame

    private void ResetBall()
    {
        ball.transform.localPosition = origin_pos;
        ball.transform.localRotation = origin_rot;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        fly = false;
        hit = false;
        StartCoroutine(DisappearAndAppear());
        //ball.SetActive(false);
        //for (int i = 0; i < 100; i++) continue;
        //ball.SetActive(true);
    }

    IEnumerator DisappearAndAppear()
    {
        // Make the ball disappear
        // Make the ball disappear by disabling its Renderer
        ball.GetComponent<Renderer>().enabled = false;

        // Wait for 'disappearTime' seconds
        yield return new WaitForSeconds(disappearTime);

        // Make the ball reappear by enabling its Renderer
        ball.GetComponent<Renderer>().enabled = true;

        // Wait for 'disappearTime' seconds before repeating the cycle
        //yield return new WaitForSeconds(disappearTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
        ResetBall();
        ContactPoint contact = collision.contacts[0];
        smoke.transform.position = contact.point;
        smoke.GetComponent<Renderer>().enabled = true;
    }
    void Update()
    {
        if (fly && !hit)
        {
            if (Time.time - start_time > 3.0f) ResetBall();
        }
        if (Input.GetMouseButtonDown(0))
        {
            thunder.Play();
            start_time = Time.time;
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * speed);
            fly = true;

        }
    }


}


