using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerLogic : MonoBehaviour
{
    public bool finishedTurn { get; protected set; } = false;
    public bool canAct { get; set; }
    public float cash;
}
