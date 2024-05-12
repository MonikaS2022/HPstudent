using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
