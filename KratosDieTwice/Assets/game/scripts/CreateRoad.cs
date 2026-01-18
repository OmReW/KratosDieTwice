using UnityEngine;
using System.Collections.Generic;

public class PrefabSpawner : MonoBehaviour {
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float distanceFromPlayer = 10f;
    [SerializeField] private int maxPrefabs = 15; 

    private float timer = 0f;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();

    void Update() {
        timer += Time.deltaTime;

        if (timer >= spawnTime) {
            SpawnPrefab();
            timer = 0f;
        }
    }
    void SpawnPrefab() {
        if (prefabToSpawn == null || player == null) {
            Debug.LogWarning("Prefab or Player not assigned!");
            return;
        }

        Vector3 spawnPos = new Vector3 (0, 0.7849599f, player.position.z + 120f);
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPos, new Quaternion(0,180,0,180));

        spawnedPrefabs.Add(newPrefab);

        if (spawnedPrefabs.Count > maxPrefabs) {
            GameObject oldestPrefab = spawnedPrefabs[0];
            spawnedPrefabs.RemoveAt(0);
            Destroy(oldestPrefab);
        }
    }
}