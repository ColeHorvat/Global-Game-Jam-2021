using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Outline outline;
    private GameObject player;
    public Vector3 lastPosition;
    public GameObject hidingPoint;
    private PlayerController playerController;

    //Monster variables
    private KillController killController;
    private GameObject monster;
    private float killDistance = 15;

    //Camera Reference
    private GameObject cam;

    //Hide variables
    private bool hidden = false;

    private bool hide = false;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        monster = GameObject.FindGameObjectWithTag("Monster");
        killController = monster.GetComponent<KillController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(killController.canKill);

        if(outline.enabled == true && Input.GetKeyDown("e") && !hidden && !hide) {
                    
            if(Vector3.Distance(player.transform.position, monster.transform.position) < killDistance)
                killController.canKill = true;
            else
                killController.canKill = false;
    

            lastPosition = player.transform.position;
            hide = true;
            playerController.isHidden = true;
        } else if(outline.enabled == false && hidden && Input.GetKeyDown("e") && hide) {
            killController.canKill = true;
            hide = false;
            playerController.isHidden = false;

        }

        if(hide && !hidden)
            StartCoroutine(hidePlayer());
        else if(!hide && hidden)
            StartCoroutine(unhidePlayer());
    }

    IEnumerator hidePlayer() {

        playerController.enabled = false;

        while (Vector3.Distance(player.transform.position, hidingPoint.transform.position) > 0.1f)
        {
            
            gameObject.GetComponent<InteractableController>().active = false;
            player.transform.localScale = new Vector3(1f, 0.2f, 1f);
            //player.GetComponent<CharacterController>().height = 0.1f;

            player.transform.position = Vector3.Lerp(player.transform.position, hidingPoint.transform.position, 7 * Time.deltaTime);

            gameObject.GetComponent<Outline>().enabled = false;
            cam.GetComponent<Headbobber>().enabled = false;

            yield return null;
        }

        hidden = true;
        Debug.Log("Hide");
    }

    IEnumerator unhidePlayer() {
        
        
        //killController.canKill = true;
        while (Vector3.Distance(player.transform.position,lastPosition) > 0.1f)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, lastPosition, 7 * Time.deltaTime);
            yield return null;
        }

        player.transform.localScale = new Vector3(1f, 1f, 1f);
        //player.GetComponent<CharacterController>().height = 1f;
        gameObject.GetComponent<InteractableController>().active = true;
        cam.GetComponent<Headbobber>().enabled = true;

        playerController.enabled = true;

        hidden = false;
        Debug.Log("Unhide");
    }
}
