using UnityEngine;
using System.Collections.Generic;

public class CreateRoad : MonoBehaviour {
    [SerializeField] private GameObject roadSpawn;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float distanceFromPlayer = 10f;
    [SerializeField] private int maxRoads = 15; 

    private float timer = 0f;
    private List<GameObject> spawnedRoads = new List<GameObject>();

    void Update() {
        timer += Time.deltaTime;

        if (timer >= spawnTime) {
            SpawnRoad();
            timer = 0f;
        }
    }
    void SpawnRoad() {
        if (roadSpawn == null || player == null) {
            Debug.LogWarning("road error");
            return;
        }

        Vector3 spawnPos = new Vector3 (0, 0.7849599f, player.position.z + 120f);
        GameObject newRoad = Instantiate(roadSpawn, spawnPos, new Quaternion(0,180,0,180));

        spawnedRoads.Add(newRoad);

        if (spawnedRoads.Count > maxRoads) {
            GameObject oldestRoad = spawnedRoads[0];
            spawnedRoads.RemoveAt(0);
            Destroy(oldestRoad);
        }
    }
}