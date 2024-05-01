using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseSurvival : MonoBehaviour
{
    [SerializeField] protected float depletionRate = 1f;
    [SerializeField] protected float current = 100;
    [SerializeField] protected float max = 100;
    public static BaseSurvival Instance { get; private set; }

    public float Current
    {
        get { return current;}
    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (current > 0)
        {
            current -= depletionRate * Time.deltaTime;
        }
    }
}
