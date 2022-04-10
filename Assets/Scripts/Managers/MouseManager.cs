using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;

    private ClickableObject previousClickableObject;
    private GameObject currentInteractiveObject;
    private TurnManager turnManager;

    private void Start()
    {
        turnManager = TurnManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnManager.gameLoopActive) return;

        RaycastHit raycastHit;

        if (currentInteractiveObject)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(currentInteractiveObject);
            }
            return;
        }

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 18, clickableLayer))
        {
            ClickableObject clickableObject = raycastHit.collider.gameObject.GetComponent<ClickableObject>();

            if (clickableObject == null)
            {
                Debug.LogError("Raycast hit entity on clickable layer without a clickable component.");
                return;
            }

            if (previousClickableObject != clickableObject)
            {
                previousClickableObject?.EndHover();
                previousClickableObject = clickableObject;
                clickableObject.Hover();
            }

            if (Input.GetMouseButtonDown(0))
            {
                currentInteractiveObject = clickableObject.Click();
            }
        }
        else
        {
            previousClickableObject?.EndHover();
            previousClickableObject = null;
        }
    }
}
