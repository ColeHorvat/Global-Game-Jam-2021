using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    public bool canKill = true;
    private Animator animator;
    public GameObject killCam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            if(canKill == true) {
                kill();
            } else {
                animator.SetFloat("alertTimer", -1f);
            }
        }
    }

    void kill() {
        playerController.enabled = false;
        GameObject.Find("Main Camera").SetActive(false);
        killCam.SetActive(true);
        animator.SetBool("kill", true);
        
    }
}
