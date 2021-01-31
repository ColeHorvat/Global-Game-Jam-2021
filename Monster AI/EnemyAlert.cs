using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAlert : StateMachineBehaviour
{
    //Player references
    private GameObject player;
    private Transform playerTransform;

    //Monster references
    private GameObject monster;
    private NavMeshAgent agent;

    //Alert timer
    public float alertTimer = 0;
    public float alertTimerTotal = 15;

    //Monster Variables
    private float alertSpeed = 14f;
    private float alertAccel = 8;
    public Vector3 lastKnownLocation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        monster = animator.gameObject;
        agent = monster.GetComponent<NavMeshAgent>();
        

        agent.speed = alertSpeed;
        agent.acceleration = alertAccel;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector3 targetDir = playerTransform.position - monster.transform.position;
        float angle = Vector3.Angle(targetDir, monster.transform.forward);
        agent.SetDestination(player.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        lastKnownLocation = playerTransform.position;

        animator.SetFloat("searchTimer", 5f);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
