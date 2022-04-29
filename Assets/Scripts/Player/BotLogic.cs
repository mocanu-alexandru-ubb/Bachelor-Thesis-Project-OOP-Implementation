using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLogic : AbstractPlayerLogic
{
    public GameObject[] minionPrefabs;
    public int spawnsPerTurn = 5;

    TurnManager turnManager;

    public void Act()
    {
        GameObject target = null;
        while (target == null)
        {
            target = turnManager.players[Random.Range(0, turnManager.players.Length)];
            if (target.gameObject.name == gameObject.name) target = null;
        }

        Debug.Log(gameObject.name + " attacking " + target.gameObject.name);

        ClickableHomebase targetHomebase = target.GetComponent<ClickableHomebase>();
        MinionSpawner minionSpawner = GetComponent<MinionSpawner>();
        //minionPrefab.GetComponent<MinionStats>().owner = gameObject.name;

        for (int i = 0; i < spawnsPerTurn; i++)
        {
            int prefabIndex = Random.Range(0, minionPrefabs.Length);
            minionSpawner.spawningQueue.Add(new MinionSpawner.MinionSpawnDto(minionPrefabs[prefabIndex], targetHomebase.transform));
        }
        finishedTurn = true;
        canAct = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        turnManager = TurnManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAct)
        {
            Act();
        }
    }
}
