using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public VisualEffect flamethrower;
    private GameObject smoke;
    private GameObject smoke1;
    void Start()
    {
        smoke = GameObject.FindGameObjectWithTag("Smoke");
        smoke.GetComponent<Renderer>().enabled = false;
        smoke1 = GameObject.FindGameObjectWithTag("Smoke1");
        smoke1.GetComponent<Renderer>().enabled = false;
        //smoke1.Stop();
        flamethrower.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flamethrower.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            flamethrower.Stop();
        }
    }
}
