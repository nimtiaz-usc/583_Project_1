using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    //public GameObject[] enemyTypes;
    public GameObject[] spawnPoints;
    private Vector3 spawnPoint;
    public float spawnRate = 10f;
    public float rateScale = 0.001f;

    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    void FixedUpdate() {
        if (spawnRate >= 1) { 
            spawnRate -= rateScale;
        }
    }
    
    IEnumerator SpawnEnemy() {
        while (true) {
            spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            var newEnemy = Instantiate(enemy, spawnPoint, Quaternion.identity) as GameObject;
            newEnemy.GetComponent<NavMeshAgent>().speed = 10f / spawnRate;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
