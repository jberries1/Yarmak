using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public int health;
    public int healthKit = 30;
    public bool fullHeal;

    public void TakeHit(int damage)
    {
        health -= damage;
        Debug.Log("Fire");
        if (health <= 0)
            Destroy(gameObject);
    }
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health > 100)
            health = 100;

    }
    public void BonusHeal (int healthKit)
    {
        health += healthKit;
        if (health > 100)
            health = 100;

        Debug.Log("Kit+");
    }
    public void FullHeal(bool fullHeal)
    {
        if (health >= 100)
        {
            fullHeal = true;
        }
        if (health <= 100)
        {
            fullHeal = false;
        }
    }



}
