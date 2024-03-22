using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> _patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30;
    public Animator animator;
    public float attackDistance = 0;
    public EnemyHealth _enemyHealth;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        InitComponentsLinks(); 
        PickPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
        CheckIfAlive();
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_enemyHealth.health > 0)
            {
                if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _enemyHealth.health > 0)
                {
                    animator.SetTrigger("attack");


                }
            }
        }
    }
    
    private void PickPatrolPoint()
    {
        _navMeshAgent.destination = _patrolPoints[Random.Range(0, _patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed) 
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance )
            {
                if(_enemyHealth.health > 0)
                {
                    PickPatrolPoint();
                }
                
            }
        }
    }
    private void InitComponentsLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        if (_playerHealth.health <= 0) return;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_enemyHealth.health > 0)
            {
                _navMeshAgent.destination = player.transform.position;
            }
            
        }
    }
    public void AttackDamage()
    {
        if (!_isPlayerNoticed) return;
        if(_enemyHealth.health > 0)
        {
            if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance + attackDistance) return;
            _playerHealth.DealDamage(damage);
        }
        
    }
    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }
    public void CheckIfAlive() 
    { 
        if (_enemyHealth.health <= 0)
        {
            _enemyHealth.EnemyDeath();

        }
    }

}