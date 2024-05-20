using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class M_EnemyP : M_Enemy
{
    [SerializeField] int increasePleasure = 5;
    public override void OnDeath()
    {
        Survival.Instance.IncreasePleasure(increasePleasure);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
