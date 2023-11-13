using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WindMove : MonoBehaviour
{
    // Start is called before the first frame update
    public VisualEffect wind;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            wind.Play();
        }
    }
}
