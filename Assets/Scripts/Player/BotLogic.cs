using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLogic : AbstractPlayerLogic
{
    public GameObject minionPrefab;

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
        minionSpawner.spawningQueue.Add(new MinionSpawner.MinionSpawnDto(minionPrefab, targetHomebase.transform));
        minionSpawner.spawningQueue.Add(new MinionSpawner.MinionSpawnDto(minionPrefab, targetHomebase.transform));
        minionSpawner.spawningQueue.Add(new MinionSpawner.MinionSpawnDto(minionPrefab, targetHomebase.transform));
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
