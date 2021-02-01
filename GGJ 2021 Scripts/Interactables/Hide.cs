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
    private Animator animator;

    //Camera Reference
    private GameObject cam;

    //Hide variables
    private bool hidden = false;

    private bool hide = false;
    public float hideTimer;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        monster = GameObject.FindGameObjectWithTag("Monster");
        if(monster != null) {
            killController = monster.GetComponent<KillController>();
            animator = monster.GetComponent<Animator>();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(killController.canKill);

        if(killController == null)
        {
            if (monster == null)
                monster = GameObject.FindGameObjectWithTag("Monster");
            else if (monster != null)
            {
                killController = monster.GetComponent<KillController>();
                animator = monster.GetComponent<Animator>();
            }
        }

        if(outline.enabled == true && Input.GetKeyDown("e") && !hidden && !hide) {
                    
            if(killController != null && Vector3.Distance(player.transform.position, monster.transform.position) < killDistance)
                killController.canKill = true;
            else if(killController != null)
                killController.canKill = false;
    

            lastPosition = player.transform.position;
            hide = true;
            playerController.isHidden = true;
        } else if(outline.enabled == false && hidden && Input.GetKeyDown("e") && hide) {
            if(killController != null)
                killController.canKill = true;
            hide = false;
            playerController.isHidden = false;

        }

        if(hide && !hidden) {
            //player.GetComponent<CharacterController>().SimpleMove(Vector3.zero);
            StartCoroutine(hidePlayer());
        }
        else if(!hide && hidden)
            StartCoroutine(unhidePlayer());
        else if(hidden && monster != null && animator.GetBool("kill") == true) {
            StartCoroutine(unhidePlayer());
            gameObject.SetActive(false);
        }

        hideTimer -= Time.deltaTime;
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
        //Debug.Log("Hide");
    }

    IEnumerator unhidePlayer() {
        
        
        //killController.canKill = true;
        while (Vector3.Distance(player.transform.position,lastPosition) > 0.25f)
        {
            //player.GetComponent<CharacterController>().SimpleMove(Vector3.zero);
            Debug.Log("While loop");
            player.transform.position = Vector3.Lerp(player.transform.position, lastPosition, 7 * Time.deltaTime);
            yield return null;
        }

        player.transform.localScale = new Vector3(1f, 1f, 1f);
        //player.GetComponent<CharacterController>().height = 1f;
        gameObject.GetComponent<InteractableController>().active = true;
        cam.GetComponent<Headbobber>().enabled = true;

        playerController.enabled = true;

        hidden = false;
        hideTimer = 1;
        //Debug.Log("Unhide");
    }
}
