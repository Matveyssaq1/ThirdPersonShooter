using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsAlive()
    {
        return health > 0;
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }
    public void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("Death", 1);
    }
    private void Death()
    {
        animator.SetTrigger("death");
        Invoke("Destroy", 3);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
