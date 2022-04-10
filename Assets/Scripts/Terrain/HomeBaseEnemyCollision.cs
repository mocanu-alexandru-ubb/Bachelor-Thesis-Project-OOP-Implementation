using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeBaseEnemyCollision : MonoBehaviour
{
    public int health { get; private set; } = 20;
    //public TextMeshProUGUI text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("collision in " + gameObject.name + " with monster of " + other.GetComponent<MinionStats>().owner);
            if (other.GetComponent<MinionStats>().owner == gameObject.name)
            {
                return;
            }
            MinionStats enemyStats = other.GetComponent<MinionStats>();
            if (enemyStats != null)
            {
                health -= enemyStats.baseDamage;
                if (health <= 0)
                {
                    Debug.Log("You lost!");
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    return;
                }
            }

            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        //text.text = "Lives: " + health;
    }

}
