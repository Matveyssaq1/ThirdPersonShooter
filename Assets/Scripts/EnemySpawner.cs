using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public int enemiesMaxCount = 5;
    public List<Transform> patrolPoints;
    public float delay = 5;
    public PlayerController player;
    
    private List<Transform> _spawnerPoints;

    private List<EnemyAI> _enemies;

    private float _timeLAstSpawned;
    
    
    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();
    }

    private void Update()
    {
        if (_enemies.Count >= enemiesMaxCount) return;

        if (Time.time - _timeLAstSpawned < delay) return;
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        enemy.player = player;
        enemy._patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLAstSpawned = Time.time;
    }
}
