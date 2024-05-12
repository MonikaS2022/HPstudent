using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class M_Objectpool : MonoBehaviour
{
    private Queue<M_Enemy> pool;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Vector3 initialSpawnLocation;

    public Queue<M_Enemy> Pool
    {
        get { return pool; }
    }
    public M_Enemy GetObject()
    {
        if (pool.Count > 0)
        {
            M_Enemy obj = pool.Dequeue();
            return obj;
        }
        else
        {
            // If pool is empty, create a new object
            M_Enemy enemy = Instantiate(enemyPrefab, initialSpawnLocation, Quaternion.identity).GetComponent<M_Enemy>();
            enemy.gameObject.SetActive(false);
            return enemy;
        }
    }
    public void ReleaseObject(M_Enemy obj)
    {
        // Reset the object's state before returning it
        obj.Reset();
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }

    public void CreateObjectPool(int size)
    {
        pool = new Queue<M_Enemy>();
        for (int i = 0; i < size; i++)
        {
            M_Enemy enemy = Instantiate(enemyPrefab, initialSpawnLocation, Quaternion.identity).GetComponent<M_Enemy>();
            enemy.gameObject.SetActive(false);
            pool.Enqueue(enemy);
        }
    }
    
}
