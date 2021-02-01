using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySearching : StateMachineBehaviour
{    
    //Player references
    private GameObject player;
    private Transform playerTransform;

    //Monster references
    private GameObject monster;
    private NavMeshAgent agent;

    //Alert timer
    public float searchTimer = 0;
    private EnemyAlert alertBehaviour;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        alertBehaviour = animator.GetBehaviour<EnemyAlert>();
        monster = animator.gameObject;
        agent = monster.GetComponent<NavMeshAgent>();
        searchTimer = 5f;
        

       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        

        animator.SetFloat("searchTimer", searchTimer);
        searchTimer -= Time.deltaTime;

        agent.velocity = new Vector3(0,0,0);
        //Stand still and do search animation
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
