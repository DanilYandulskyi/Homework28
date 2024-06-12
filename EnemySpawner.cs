using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] private List<SpawnPoint> _spawners;

    private int _waitTime = 2;

    private void Awake()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_waitTime);
        bool isSpawning = true;

        while (isSpawning)
        {
            SpawnPoint point = _spawners[Random.Range(0, _spawners.Count)];

            yield return waitTime;
            point.Spawn();
        }
    }
}
