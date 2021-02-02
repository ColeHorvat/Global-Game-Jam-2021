using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Outline outline;
    private GameObject hand;
    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        hand = GameObject.Find("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if(outline.enabled == true && Input.GetKey("e")) {
            gameObject.transform.position = hand.transform.position;
            gameObject.transform.parent = hand.transform;

            gameObject.GetComponent<Collider>().enabled = false;

            hasKey = true;
        }
            
    }
}
