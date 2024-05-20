using UnityEngine;
using UnityEngine.AI;

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
        player = GameObject.FindGameObjectWithTag("M_Player");

        if (this.CompareTag("Enemy"))
        {
            TransitionTo(new ChaseState(this));
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
        }
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

    protected void TransitionTo(State state)
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

    protected abstract class State
    {
        public virtual void Enter() { }
        public virtual void Update() { }

        protected M_Enemy stateMachine;

        public State(M_Enemy stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
    protected class AttackingState : State
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


    protected class ChaseState : State
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
    protected class FallState : State
    {
        public FallState(M_Enemy stateMachine) : base(stateMachine)
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
