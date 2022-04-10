using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableHomebase : ClickableObject
{
    public Material defaultMaterial;
    public Material highlightMaterial;
    public Material selectedMaterial;

    public GameObject attackMenuPrefab;

    private TurnManager turnManager;
    private MeshRenderer meshRenderer;

    public override GameObject Click()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject buildMenu = Instantiate(attackMenuPrefab, canvas.transform);
        buildMenu.GetComponent<AttackMenu>().init(gameObject, turnManager.currentPlayer);
        return buildMenu;
    }

    public override void Hover()
    {
        meshRenderer.material = highlightMaterial;
    }

    public override void EndHover()
    {
        meshRenderer.material = defaultMaterial;
    }

    private void Start()
    {
        turnManager = TurnManager.getInstance();
        gameObject.layer = LayerMask.NameToLayer("Clickable");
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public override void Selected()
    {
        meshRenderer.material = selectedMaterial;
    }

    public override void EndSelected()
    {
        EndHover();
    }
}
