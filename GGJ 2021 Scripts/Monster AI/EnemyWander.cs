using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : StateMachineBehaviour
{

    //Wander Variables
    private float walkRadius = 50f;

    private Vector3 finalPosition;
    private float stillTimer = 0;
    private float stillTimerTime = 2;

    //Monster Variables
    private GameObject monster;
    private float wanderSpeed = 3f;
    private float wanderAccel = 2f;
    private NavMeshAgent agent;

    //Player Reference
    private GameObject player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        monster = animator.gameObject;
        agent = monster.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");

        agent.speed = wanderSpeed;
        agent.acceleration = wanderAccel;
        
        Wander();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        /*
        if(finalPosition.x == (monster.transform.position.x) && finalPosition.z == monster.transform.position.z) {
                Wander(); 
        }
        */
        if(Vector3.Distance(finalPosition, monster.transform.position) <= 4.5f) {
            agent.velocity = new Vector3 (0,0,0);
            Wander();
        }
        
        //Debug.Log(Vector3.Distance(finalPosition, monster.transform.position));
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

     
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

    public void Wander() {
        
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += monster.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        finalPosition = hit.position;

        if(Vector3.Distance(player.transform.position, finalPosition) < 40) {
            monster.GetComponent<NavMeshAgent>().destination = finalPosition;
        } else {
            Wander();
        }
        


    }
}
