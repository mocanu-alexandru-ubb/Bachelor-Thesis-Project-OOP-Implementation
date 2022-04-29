using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTowerShoot : BaseTowerShoot
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private float fireCooldown = 0;
    private TurnManager turnManager;

    private void Start()
    {
        turnManager = TurnManager.getInstance();
    }
    private void Fire(Transform target)
    {
        GameObject spawnedBullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        BasicBulletFollow basicBulletFollow = spawnedBullet.GetComponent<BasicBulletFollow>();
        if (basicBulletFollow != null)
        {
            basicBulletFollow.setTarget(target, damage);
        }
    }

    public override void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (!turnManager.gameLoopActive) return;
        if (target)
        {
            if (fireCooldown <= 0)
            {
                Fire(target);
                fireCooldown += 1 / rateOfFire;
            }
        }
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
    }
}
