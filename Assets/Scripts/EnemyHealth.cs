﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    public Explosion explosionPrefab;
    public PlayerProgress playerProgress; 
    // Start is called before the first frame update
    void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
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
        playerProgress.AddExperience(damage);
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
        Invoke("Death", 2);
        
    }
    private void Death()
    {
        animator.SetTrigger("death");
        MobExplosion();
        Invoke("Destroy", 3);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    private void MobExplosion()
    {
        if (explosionPrefab == null) return;
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
