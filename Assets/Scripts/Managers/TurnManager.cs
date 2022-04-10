using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public float turnDuration = 10;
    private float turnTimer = 10;
    public bool gameLoopActive { get; private set; } = false;
    public GameObject currentPlayer { get; private set; }
    private AbstractPlayerLogic currentPlayerLogic;
    public GameObject[] players;
    private int playerIndex = 0;

    private static TurnManager instance;
    public static TurnManager getInstance()
    {
        return instance;
    }

    public void Awake()
    {
        instance = this;
        currentPlayer = players[playerIndex];
    }

    public void Start()
    {
        currentPlayerLogic = players[playerIndex].GetComponent<AbstractPlayerLogic>();
    }

    private void Update()
    {
        if (gameLoopActive)
        {
            if (turnTimer <= 0)
            {
                Debug.Log("Turn finished.");
                gameLoopActive = false;
                currentPlayerLogic.canAct = true;
                turnTimer += turnDuration;
                foreach(var player in players)
                {
                    player.GetComponent<AbstractPlayerLogic>().cash += 300;
                }
            }
            if (turnTimer > 0)
            {
                turnTimer -= Time.deltaTime;
            }
        }
        else
        {
            if (currentPlayerLogic.finishedTurn)
            {
                if (currentPlayerLogic.gameObject.CompareTag("Player"))
                {
                    ((PlayerLogic)currentPlayerLogic).Reset();
                }

                playerIndex++;
                if (playerIndex >= players.Length)
                {
                    currentPlayerLogic.canAct = false;
                    playerIndex = 0;
                    gameLoopActive = true;
                    currentPlayer = players[playerIndex];
                    currentPlayerLogic = players[playerIndex].GetComponent<AbstractPlayerLogic>();
                }
                else
                {
                    currentPlayer = players[playerIndex];
                    currentPlayerLogic = players[playerIndex].GetComponent<AbstractPlayerLogic>();
                    currentPlayerLogic.canAct = true;
                }
                Debug.Log("Moving on to " + currentPlayerLogic.gameObject.name);
            }
        }
    }
    private TurnManager(){}
}
