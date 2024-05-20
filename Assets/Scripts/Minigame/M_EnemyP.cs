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

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        TransitionTo(new FallState(this));
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
