using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour

{
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("No Teg Player");
            Health health = col.gameObject.GetComponent<Health>();
            health.BonusHeal(30);
            if (!health.fullHeal)
            {
                Destroy(gameObject);
            }
            

        }
    }
    
}
