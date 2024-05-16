using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public abstract class M_Enemy : MonoBehaviour
{
    public float health = 1;
    protected float maxHealth = 1;

    [SerializeField] protected float speed = 10f;
    protected NavMeshAgent agent;

    [SerializeField] State state { get; set; }

    protected GameObject player;
    public void Start()
    {
        Reset();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("M_Player");
        agent.speed = speed;

        TransitionTo(new ChaseState(this));
    }

    // Update is called once per frame
    public void Update()
    {
        if (state != null)
        {
            state.Update();
        }
    }

    public void Reset()
    {
        health = maxHealth;
    }

    void TransitionTo(State state)
    {
        //Debug.Log($"Context: Transition to {state.GetType().Name}.");
        this.state = state;
        this.state.Enter();
    }

    public void Chasing()
    {
        agent.SetDestination(player.transform.position);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TransitionTo(new DeathState(this));
        }
    }

    public abstract void OnDeath();

    abstract class State
    {
        public virtual void Enter() { }
        public virtual void Update() { }

        protected M_Enemy stateMachine;

        public State(M_Enemy stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
    class AttackingState : State
    {
        public AttackingState(M_Enemy stateMachine) : base(stateMachine)
        {

        }
        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

        }
    }


    class ChaseState : State
    {
        public ChaseState(M_Enemy stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            stateMachine.Chasing();
            base.Update();
        }
    }

    class DeathState : State
    {
        public DeathState(M_Enemy stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            stateMachine.OnDeath();
            base.Enter();
        }

        public override void Update()
        {

            base.Update();
        }
    }
}
