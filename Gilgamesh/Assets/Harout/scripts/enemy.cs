using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class enemy : MonoBehaviour
{
    public EnemyState currentState;
    public floatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    Animator anim;
    bool death;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }


    private void Start()
    {
        health = maxHealth.initialValue;
        anim = GetComponent<Animator>();
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            //  this.gameObject.SetActive(false);
            
            anim.SetTrigger("dead");
        }

    }
    public void Knock (Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }


    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;

        }

    }

}
