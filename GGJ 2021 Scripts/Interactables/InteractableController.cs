using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    private Outline outline;
    private GameObject player;

    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        player = GameObject.Find("Player");
        active = true;
    }

    private void OnMouseOver()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 5 && active)
            outline.enabled = true;
    }

    private void OnMouseExit()
    {
        if(active)
            outline.enabled = false;
    }
}
