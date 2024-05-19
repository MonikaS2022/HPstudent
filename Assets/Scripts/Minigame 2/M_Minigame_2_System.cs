using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Minigame_2_System : M_Systems
{
    [SerializeField] M_Objectpool poolBanan;
    [SerializeField] M_Objectpool poolBurger;
    [SerializeField] M_Objectpool poolCherry;
    [SerializeField] M_Objectpool poolOlive;
    [SerializeField] M_Objectpool poolHotDog;
    [SerializeField] M_Objectpool poolWatermelon;
    [SerializeField] M_Objectpool poolCheese;
    [SerializeField] int amountEnemies = 20;
    [SerializeField] float spawnTime = 2f;
    Vector3 playerPosition;

    List<M_Enemy> enemies;
    bool shouldSpawn = true;

    float spawnTimer = 2f;
    [SerializeField] GameObject[] spawnPoints;

    void Start()
    {
       
    }
    void Update()
    {
        if (!Survival.Instance.inMinigame2)
        {
            return;
        }

        Debug.Log(shouldSpawn.ToString() + ", "+ enemies.Count + ", "+ amountEnemies);

        if (shouldSpawn && enemies.Count < amountEnemies + (amountEnemies / 4))
        {

            M_Enemy enemy;
            if (Random.Range(0, 6) == 0)
            {
                enemy = poolBanan.GetObject();
            }
            else if (Random.Range(0, 6) == 1)
            {
                enemy = poolBurger.GetObject();
            }
            else if (Random.Range(0, 6) == 2)
            {
                enemy = poolCherry.GetObject();
            }
            else if (Random.Range(0, 6) == 3)
            {
                enemy = poolHotDog.GetObject();
            }
            else if (Random.Range(0, 6) == 4)
            {
                enemy = poolOlive.GetObject();
            }
            else if (Random.Range(0, 6) == 5)
            {
                enemy = poolCheese.GetObject();
            }
            else
            {
                enemy = poolWatermelon.GetObject();
            }

            enemies.Add(enemy);
            Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;

            enemy.transform.position = spawnPoint;
            enemy.gameObject.SetActive(true);
            shouldSpawn = false;
            StartCoroutine(SpawnTimer(spawnTimer));
        }


        //CheckForHealth();

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].health <= 0)
            {
                if (enemies[i] is Minigame_2_Enemy_Banan)
                {
                    poolBanan.ReleaseObject(enemies[i]);
                }
                else if (enemies[i] is Minigame_2_Enemy_Burger)
                {
                    poolBurger.ReleaseObject(enemies[i]);
                }
                else if (enemies[i] is Minigame_2_Enemy_Cheese)
                {
                    poolCheese.ReleaseObject(enemies[i]);
                }
                else if (enemies[i] is Minigame_2_Enemy_Cherry)
                {
                    poolCherry.ReleaseObject(enemies[i]);
                }
                else if (enemies[i] is Minigame_2_Enemy_HotDog)
                {
                    poolHotDog.ReleaseObject(enemies[i]);
                }
                else if (enemies[i] is Minigame_2_Enemy_Olive)
                {
                    poolOlive.ReleaseObject(enemies[i]);
                }
                else if (enemies[i] is Minigame_2_Enemy_Watermelon)
                {
                    poolWatermelon.ReleaseObject(enemies[i]);
                }

                enemies.RemoveAt(i);
            }

        }

    }

    public override void StartGame()
    {
        shouldSpawn = true;

        enemies = new List<M_Enemy>();
        poolBanan.CreateObjectPool(amountEnemies);
        poolBurger.CreateObjectPool(amountEnemies);
        poolCherry.CreateObjectPool(amountEnemies);
        poolOlive.CreateObjectPool(amountEnemies);
        poolHotDog.CreateObjectPool(amountEnemies);
        poolWatermelon.CreateObjectPool(amountEnemies);
        poolCheese.CreateObjectPool(amountEnemies);

        Survival.Instance.inMinigame2 = true;
    }

    public override void StopGame()
    {
        base.StopGame();

        shouldSpawn = false;

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] is Minigame_2_Enemy_Banan)
            {
                poolBanan.ReleaseObject(enemies[i]);
            }
            else if (enemies[i] is Minigame_2_Enemy_Burger)
            {
                poolBurger.ReleaseObject(enemies[i]);
            }
            else if (enemies[i] is Minigame_2_Enemy_Cheese)
            {
                poolCheese.ReleaseObject(enemies[i]);
            }
            else if (enemies[i] is Minigame_2_Enemy_Cherry)
            {
                poolCherry.ReleaseObject(enemies[i]);
            }
            else if (enemies[i] is Minigame_2_Enemy_HotDog)
            {
                poolHotDog.ReleaseObject(enemies[i]);
            }
            else if (enemies[i] is Minigame_2_Enemy_Olive)
            {
                poolOlive.ReleaseObject(enemies[i]);
            }
            else if (enemies[i] is Minigame_2_Enemy_Watermelon)
            {
                poolWatermelon.ReleaseObject(enemies[i]);
            }
            enemies.Remove(enemies[i]);
            Survival.Instance.inMinigame2 = false;

        }
    }

    IEnumerator SpawnTimer(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);

        shouldSpawn = true;
    }



}
