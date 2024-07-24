using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krabing : MonoBehaviour
{
    private bool groundissimo;
    private Vector3 modir = Vector3.zero;
    private Transform gosform;
    public float aids=10;
    public float jaids=30;
    private float grv = 100;
    private CharacterController ccont;
    void Start()
    {
        gosform = GetComponent<Transform>();
        ccont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        modir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        modir = gosform.TransformDirection(modir);
        modir *= aids;

        if(groundissimo)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                modir.y=jaids;
            }
        }
        modir.y -= grv * Time.deltaTime * gosform.up.y;
        ccont.Move(modir*Time.deltaTime);
    }
    void OnCollisionEnter(Collision collition)
    {
        if(collition.gameObject.tag == "grond")
        {
            groundissimo = true;
        }
    }
    void OnCollisionExit(Collision collition)
    {
        if(collition.gameObject.tag == "grond")
        {
            groundissimo = false;
        }
    }
}
