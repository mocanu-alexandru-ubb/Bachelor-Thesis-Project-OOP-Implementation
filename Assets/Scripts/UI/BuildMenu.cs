using Michsky.UI.Shift;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject towerPrefab;
    public Material towerTileMaterial;
    public FriendsPanelManager friendsPanelManager;

    private GameObject callingObject;
    private ClickableObject clickableObject;
    private bool builtTower = false;

    public void init(GameObject spawnLocation)
    {
        callingObject = spawnLocation;
        clickableObject = callingObject.GetComponent<ClickableObject>();
        clickableObject.Selected();
    }

    private void Start()
    {
        friendsPanelManager.WindowIn();
    }

    public void BuildTower()
    {
        PlayerLogic playerLogic = TurnManager.getInstance().currentPlayer.GetComponent<PlayerLogic>();
        if (playerLogic.cash < 500) return;
        playerLogic.cash -= 500;

        GameObject tower = Instantiate(towerPrefab, callingObject.transform.position, callingObject.transform.rotation);
        tower.GetComponent<TowerTargetSelect>().owner = TurnManager.getInstance().currentPlayer.name;
        builtTower = true;
        Destroy(gameObject);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (builtTower)
        {
            callingObject.GetComponent<ClickableTile>().defaultMaterial = towerTileMaterial;
        }
        clickableObject.EndSelected();
    }

}
