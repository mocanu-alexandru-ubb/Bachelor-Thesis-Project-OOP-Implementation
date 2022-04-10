using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : ClickableObject
{
    public Material defaultMaterial;
    public Material highlightMaterial;
    public Material selectedMaterial;
    public GameObject buildMenuPrefab;

    private MeshRenderer meshRenderer;

    public override GameObject Click()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject buildMenu = Instantiate(buildMenuPrefab, canvas.transform);
        buildMenu.GetComponent<BuildMenu>().init(gameObject);
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
