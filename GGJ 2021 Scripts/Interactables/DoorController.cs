using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openSpeed = 4;
    public AudioClip open;

    private GameObject key;
    private KeyController keyController;
    private Outline outline;
    private float doorOpenTime = 5;
    public GameObject openObject;
    private Vector3 openPoint;
    public GameObject closeObject;
    private Vector3 closePoint;
    public bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key");
        keyController = key.GetComponent<KeyController>();
        outline = gameObject.GetComponent<Outline>();
        openPoint = openObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(outline.enabled == true && keyController.hasKey == true && Input.GetKey("e")) {
            keyController.hasKey = false;
            Destroy(key);
            GetComponent<AudioSource>().PlayOneShot(open);
            isOpening = true;
        }

        if(isOpening == true)
            transform.position = Vector3.Lerp(transform.position, openPoint, openSpeed*Time.deltaTime);

        if(Vector3.Distance(transform.position, openPoint) < 0.5) {
            isOpening = false;
        }
    }
}
