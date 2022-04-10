using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTowerShoot : MonoBehaviour 
{
    public float rateOfFire = 1;
    public int damage = 1;
    protected    Transform target;
    public abstract void SetTarget(Transform target);
}
