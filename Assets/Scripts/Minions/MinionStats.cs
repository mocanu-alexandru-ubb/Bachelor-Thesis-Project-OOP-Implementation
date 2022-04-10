using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStats : MonoBehaviour
{
    public int baseHealth = 5;
    public int baseDamage  = 1;
    public float speed = 1;
    public string owner;

    private int currentHealth;

    void Start()
    {
        currentHealth = baseHealth;
    }

    public void takeDamage (int damage)
    {
        currentHealth -= damage;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
