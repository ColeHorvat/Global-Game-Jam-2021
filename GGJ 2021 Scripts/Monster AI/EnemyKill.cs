using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : StateMachineBehaviour
{
    private Vector3 killPoint;
    private GameObject player;
    public Animator artAnimator;
    private float killTimer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player");

        artAnimator = animator.transform.Find("Graphics").GetComponent<Animator>();
        
        //Debug.Log("Kill");
        //player.transform.position = killPoint;

        //Play kill animation

        //Cut to black and set kill (animator parameter) to false

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        killTimer = animator.GetFloat("killTime");
        Debug.Log(killTimer);
        if(killTimer >= 1) {
            if(SceneManager.GetActiveScene().name == "Final-Scene") {
                SceneManager.LoadScene("Thank-You-Scene");
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //reload scene
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
