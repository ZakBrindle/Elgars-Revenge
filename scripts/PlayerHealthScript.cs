using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    public int health;
    public int shield = 0;

    public int maxHealth = 100;

    public HealthbarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        int t = (int)Random.Range(damage-(damage/2), damage);
        if(shield <= 0)
        {
            if(shield < 0)
            {
                shield = 0;  //fix shield if less than   
            }

            health -= t; 
            if(health < 0)
            {
                health = 0; //fix health if less than   
            }           
        }
        else
        {
            //got shield
            shield -= t;
            if(shield < 0)
            {
                shield = 0; //fix shield if less than   
            }
        }
        healthBar.SetHealth((int)health);
        print("Take Damage: " + t.ToString() + "    Health: " + health.ToString());
        if(health <= 0)
        {
            print("You Dead!");
            gameObject.GetComponent<AIPlayerControl>().SetIsDead(true);
        }
    }
}
