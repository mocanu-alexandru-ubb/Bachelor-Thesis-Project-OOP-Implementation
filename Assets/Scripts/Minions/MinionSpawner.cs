using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public class MinionSpawnDto
    {
        public GameObject minionPrefab;
        public Transform target;

        public MinionSpawnDto(GameObject minionPrefab, Transform target)
        {
            this.minionPrefab = minionPrefab;
            this.target = target;
        }
    }

    public float spawnRate = 1;
    public List<MinionSpawnDto> spawningQueue = new List<MinionSpawnDto> ();

    private TurnManager turnManager;
    private float spawnCooldown = 0;

    void Start()
    {
        turnManager = TurnManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (!turnManager.gameLoopActive) return;

        if (spawningQueue.Count > 0)
        {
            if (spawnCooldown <= 0)
            {
                MinionSpawnDto minionSpawnDto = spawningQueue[0];
                GameObject spawnedMinion = Instantiate(minionSpawnDto.minionPrefab, transform.position, transform.rotation);
                spawnedMinion.GetComponent<TestAgentWalk>().target = minionSpawnDto.target;
                spawnedMinion.GetComponent<MinionStats>().owner = gameObject.name;
                spawningQueue.RemoveAt(0);
                spawnCooldown += 1 / spawnRate + Random.value / 10 - 0.05f;
            }
        }
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        }

    }
}
