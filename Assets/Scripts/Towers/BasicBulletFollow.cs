using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletFollow : MonoBehaviour
{
    public float speed = 15;
    private Transform target;
    private int damage;

    public void setTarget(Transform target, int damage)
    {
        this.target = target;
        this.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceToMove = speed * Time.deltaTime;
        if (direction.sqrMagnitude < distanceToMove * distanceToMove)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceToMove, Space.World);
    }

    private void HitTarget()
    {
        MinionStats enemyStats = target.GetComponent<MinionStats>();
        if (enemyStats != null)
        {
            enemyStats.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
