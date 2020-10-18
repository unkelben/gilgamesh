using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    public float damage;






    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))

        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    hit.GetComponent<enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<enemy>().Knock(hit, knockTime, damage);
                }
                
                if (other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<player_movement>().currentState = PlayerState.stagger;
                    other.GetComponent<player_movement>().Knock(knockTime);
                }

              
            }

        }
    }



}
