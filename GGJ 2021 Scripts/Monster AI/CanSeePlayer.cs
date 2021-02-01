using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : MonoBehaviour
{

    Animator animator;
    public GameObject player;
    public bool canSee;
    public float viewRange = 50f;

    private PlayerController playerController;

    public float alertTimer = 0;
    private float alertTimerTotal = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = gameObject.GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        canSeePlayer();

        if(canSee == true) {
            alertTimer = alertTimerTotal;
            animator.SetFloat("alertTimer", alertTimerTotal);
        }

        alertTimer -= Time.deltaTime;
        animator.SetFloat("alertTimer", alertTimer);
    }

    void canSeePlayer() {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if((Vector3.Angle(rayDirection, transform.forward)) < viewRange) {
            
            if(Physics.Raycast(transform.position, rayDirection, out hit)) {
                if(hit.collider.tag == "Player" && playerController.isHidden == false) {
                    //Debug.Log("See");
                    canSee = true;
                    return;
                } else {
                    //Debug.Log("Can't see");
                    canSee = false;
                }
            }
        }
        canSee = false;
    }
}
