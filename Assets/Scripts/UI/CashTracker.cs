using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashTracker : MonoBehaviour
{
    private TurnManager turnManager;
    private GameObject currentPlayer;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        turnManager = TurnManager.getInstance();
        currentPlayer = turnManager.currentPlayer;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer.CompareTag("Player"))
        {
            if (currentPlayer != turnManager.currentPlayer)
            {
                currentPlayer = turnManager.currentPlayer;
            }
            text.text = "Cash: " + currentPlayer.GetComponent<PlayerLogic>().cash;
        }
        currentPlayer = turnManager.currentPlayer;
    }
}
