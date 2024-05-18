using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Minigame_1_System : M_Systems
{
    [SerializeField] GameObject player;
    [SerializeField] M_Objectpool poolP;
    [SerializeField] M_Objectpool poolK;
    [SerializeField] int amountEnemies;
    [SerializeField] float spawnTime = 2f;
    Vector3 playerPosition;

    List<M_Enemy> enemies;
    bool shouldSpawn = true;

    float spawnTimer = 2f;
    [SerializeField] GameObject[] spawnPoints;

    void Start()
    {
        playerPosition = player.transform.position;
        poolP.CreateObjectPool(amountEnemies);
        poolK.CreateObjectPool(amountEnemies / 4);
        enemies = new List<M_Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Survival.Instance.inMinigame1)
        {
            return;
        }

        if (shouldSpawn && enemies.Count < amountEnemies + (amountEnemies / 4))
        {

            M_Enemy enemy;
            if (Random.Range(0, 10) == 1)
            {
                enemy = poolK.GetObject();
            }
            else
            {
                enemy = poolP.GetObject();
            }

            enemies.Add(enemy);
            Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;

            enemy.transform.position = spawnPoint;
            enemy.gameObject.SetActive(true);
            shouldSpawn = false;
            StartCoroutine(SpawnTimer(spawnTimer));
        }


        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].health <= 0)
            {
                if (enemies[i] is M_EnemyK)
                {
                    poolK.ReleaseObject(enemies[i]);
                }
                else if (enemies[i] is M_EnemyP)
                {
                    poolP.ReleaseObject(enemies[i]);
                }

                enemies.RemoveAt(i);
            }

        }

    }

    public override void StartGame()
    {
        shouldSpawn = true;

        Survival.Instance.inMinigame1 = true;

        player.GetComponent<M_PlayerController>().ResetHealth();
    }

    public override void StopGame()
    {
        player.transform.position = playerPosition;
        shouldSpawn = false;

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] is M_EnemyK)
            {
                poolK.ReleaseObject(enemies[i]);
            }
            else if (enemies[i] is M_EnemyP)
            {
                poolP.ReleaseObject(enemies[i]);
            }
            enemies.Remove(enemies[i]);

            Survival.Instance.inMinigame1 = false;
        }
    }

    IEnumerator SpawnTimer(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);

        shouldSpawn = true;
    }
}
