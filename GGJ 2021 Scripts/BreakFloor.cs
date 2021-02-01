using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokyFloor : MonoBehaviour
{
    public GameObject[] floorPieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(GameObject floor in floorPieces)
            {
                floor.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
