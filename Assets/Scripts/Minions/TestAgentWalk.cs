using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAgentWalk : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private NavMeshAgent agent;
    private TurnManager turnManager;

    private bool previousGameState;
    // Start is called before the first frame update
    void Start()
    {
        turnManager = TurnManager.getInstance();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetFloat("Offset", Random.value);
    }

    private void Update()
    {
        if (previousGameState != turnManager.gameLoopActive)
        {
            if (turnManager.gameLoopActive)
            {
                agent.SetDestination(target.transform.position);
            }
            else
            {
                agent.SetDestination(transform.position);
            }
            previousGameState = turnManager.gameLoopActive;
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
