using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{
    public Animator logicAnim;
    private Animator anim;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Search", logicAnim.GetFloat("searchTimer") > 0);
        anim.SetBool("Kill", logicAnim.GetBool("kill"));
        anim.SetFloat("Speed", agent.velocity.magnitude, 0.1f, Time.deltaTime);
        logicAnim.SetFloat("killTime", anim.GetFloat("killTime"));
    }
}
