using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public GameObject kEnemyPrefab;
    public int kMaxEnemies = 50;
    public float kSpawnRadius = 10.0f;
    
    GameObject mPlayer;
    ArrayList mEnemies = new ArrayList();
    
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnEnemies());
    }
    
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (mEnemies.Count < kMaxEnemies)
            {
                Vector3 spawnPos = GetRandomSpawnPosition();
                spawnPos.y = 0;
                GameObject enemy = Instantiate(kEnemyPrefab, spawnPos, Quaternion.Euler(mPlayer.transform.position - spawnPos));
                enemy.GetComponent<Monster>().SetPlayer(mPlayer);
                mEnemies.Add(enemy);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 resultPosition = Vector3.zero;
        Vector3 randomDirection = Random.insideUnitSphere * kSpawnRadius + mPlayer.transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, kSpawnRadius, NavMesh.AllAreas) == true)
        {
            resultPosition = hit.position;
        }

        return resultPosition;
    }
}
