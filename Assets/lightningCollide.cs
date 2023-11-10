using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class lightningCollide : MonoBehaviour
{
    // Start is called before the first frame update
    public VisualEffect smoke;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        smoke.transform.position = contact.point;
        smoke.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
