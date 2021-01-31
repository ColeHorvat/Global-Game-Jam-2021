using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private GameObject key;
    private KeyController keyController;
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key");
        keyController = key.GetComponent<KeyController>();
        outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(outline.enabled == true && keyController.hasKey == true && Input.GetKey("e")) {
            keyController.hasKey = false;
            Destroy(gameObject);
            Destroy(key);
        }
    }
}
