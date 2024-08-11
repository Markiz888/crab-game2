using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainHero : MonoBehaviour
{
    private bool groundissimo;
    public float horinput;
    public float aids = 10;
    float jurce = 300;
    Rigidbody rig;
    public GameObject[] gronds;
    public float distToTP;
    public GameObject tpTo;
    void Start()
    {
        gronds = GameObject.FindGameObjectsWithTag("grond");
        rig = GetComponent<Rigidbody>();
        tpTo = gronds[0];
    }

    // Update is called once per frame
    void Update()
    {
        horinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * aids * horinput);
        if(Input.GetKeyDown(KeyCode.Space)&&groundissimo)
        {
            rig.AddForce(Vector3.up*jurce);
            groundissimo = false;
        }
        distToTP = Vector3.Distance(transform.position, tpTo.transform.position);
    }
    void OnCollisionEnter(Collision collition)
    {
        if(collition.gameObject.tag == "grond")
        {
            groundissimo = true;
        }
        if(collition.gameObject.tag == "spiks")
        {
            for(int i = 0; i < gronds.Length; i++)
            {
                float distToCur = Vector3.Distance(transform.position, gronds[i].transform.position);
                if(distToCur < distToTP)
                {
                    tpTo = gronds[i];
                    distToTP = distToCur;
                }
            }
            transform.position = new Vector3(tpTo.transform.position.x, tpTo.transform.position.y + 1, tpTo.transform.position.z);
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
