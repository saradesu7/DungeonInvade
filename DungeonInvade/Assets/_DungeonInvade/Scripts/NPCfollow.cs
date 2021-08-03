using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCfollow : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
       
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agent.destination = target.position;
        if (agent.velocity.magnitude >= 0.1f)
        {
            animator.SetBool("walk", true);

        }
        else
        {
            animator.SetBool("walk", false);
        }
    }
}
