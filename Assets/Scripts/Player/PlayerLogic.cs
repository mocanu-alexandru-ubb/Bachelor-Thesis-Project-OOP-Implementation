using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLogic : AbstractPlayerLogic
{
    public TextMeshProUGUI livesText;
    public HomeBaseEnemyCollision homeBase;
    public void FinishTurn() { finishedTurn = true; }
    public void Reset()
    {
        finishedTurn = false;
        canAct = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + homeBase.health;
    }
}
