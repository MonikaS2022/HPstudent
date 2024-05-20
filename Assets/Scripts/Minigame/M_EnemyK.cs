using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class M_EnemyK : M_Enemy
{
    [SerializeField] int increaseKnowledge = 10;
    public override void OnDeath()
    {
        Survival.Instance.IncreaseKnowledge(increaseKnowledge);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
