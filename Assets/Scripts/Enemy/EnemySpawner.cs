using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector2 spawnDistanceDelta;

    private int objectsNumber;
    [SerializeField] private int objectsNumberMax = 100;




    private float spawnTimer;
    [SerializeField] private float spawnTimerMax = 2f;

    private void Start() {
        spawnTimer = spawnTimerMax;
    }

    private void Update() {
        Spawner();
    }

    private void Spawner() {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f && objectsNumber < objectsNumberMax) {
            spawnTimer = spawnTimerMax;
            objectsNumber ++;
            Instantiate(enemyPrefab, GetSpawnPoint(), Quaternion.identity);
        }        
    }

    private Vector3 GetSpawnPoint() {
        float angle = UnityEngine.Random.Range(0f, 2 * math.PI);
        float x = spawnPoint.position.x + 25 * math.cos(angle); 
        float y = spawnPoint.position.y + 25 * math.sin(angle);

        return new Vector3(x, y, 0);
    }









}