using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    private GameObject door;
    private GameObject botObject;
    private Vector3 botPoint;
    public bool isClosing = false;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        botObject = GameObject.Find("BotPoint");
        botPoint = botObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isClosing == true) 
            door.transform.position = Vector3.Lerp(door.transform.position, botPoint, 5*Time.deltaTime);

        if(door.transform.position == botPoint) {
            isClosing = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Door")) {
            isClosing = true;
        }
    }

    void closeDoor() {
        

    }
}

