using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerTargetSelect : MonoBehaviour
{
    public Transform pivot;
    public float damping;
    public string owner;

    private List<Transform> possibleTargets = new List<Transform>();
    private Transform target;
    private BaseTowerShoot targetShoot;
    private TurnManager turnManager;

    private void Start()
    {
        turnManager = TurnManager.getInstance();
        targetShoot = gameObject.GetComponent<BaseTowerShoot>();
        if (targetShoot == null)
        {
            Debug.LogError("Tower does not have shooting mechanism!");
        }
    }

    private class SortTransformsByRemainingDistance : IComparer<Transform>
    {
        public int Compare(Transform x, Transform y)
        {
            NavMeshAgent agentX = x.GetComponent<NavMeshAgent>();
            NavMeshAgent agentY = y.GetComponent<NavMeshAgent>();
            return agentX.remainingDistance <= agentY.remainingDistance ? 1 : -1;
        }
    }

    void Update()
    {
        if (!turnManager.gameLoopActive) return;

        if (target == null && possibleTargets.Count > 0)
        {
            possibleTargets.RemoveAll(x => x == null);
            if (possibleTargets.Count <= 0) return;
            possibleTargets.Sort(new SortTransformsByRemainingDistance());
            target = possibleTargets[0];
            targetShoot.SetTarget(target);
            possibleTargets.RemoveAt(0);
        }
        if (target != null)
        {
            var lookPos = target.position - pivot.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            pivot.rotation = Quaternion.Slerp(pivot.rotation, rotation, Time.deltaTime * damping);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<MinionStats>().owner != owner)
                possibleTargets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (target == other.transform)
            {
                target = null;
                targetShoot.SetTarget(target);
            }
            possibleTargets.Remove(other.transform);
        }

    }
}
