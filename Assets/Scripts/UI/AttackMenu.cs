using Michsky.UI.Shift;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMenu : MonoBehaviour
{
    public GameObject enemyPrefab;
    public FriendsPanelManager friendsPanelManager;

    private GameObject targetHomebase;
    private ClickableObject targetHomebaseClickable;
    private MinionSpawner spawnPointEnemySpawner;

    public void init(GameObject callingObject, GameObject spawnPoint)
    {
        spawnPointEnemySpawner = spawnPoint.GetComponent<MinionSpawner>();
        targetHomebase = callingObject;
        targetHomebaseClickable = targetHomebase.GetComponent<ClickableObject>();
        targetHomebaseClickable.Selected();
    }

    private void Start()
    {
        friendsPanelManager.WindowIn();
    }

    public void SpawnEnemy()
    {
        PlayerLogic playerLogic = TurnManager.getInstance().currentPlayer.GetComponent<PlayerLogic>();
        if (playerLogic.cash < 100) return;
        playerLogic.cash -= 100;

        spawnPointEnemySpawner.spawningQueue.Add(new MinionSpawner.MinionSpawnDto(enemyPrefab, targetHomebase.transform));
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        targetHomebaseClickable.EndSelected();
    }

}
