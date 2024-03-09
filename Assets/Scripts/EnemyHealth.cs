﻿using System.Collections;
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
    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
