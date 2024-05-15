using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveState : BaseState
{
    [SerializeField] Vector3 _target;

    public MoveState(SiblingController siblingController) : base ("Move", siblingController)
    {

    }

    public override void Enter()
    {
        
    }

    public bool UpdateLogic(GameObject gObject)
    {

        var position = gObject.transform.position;
        var distance = Vector3.Distance(position, _target);
        if (gObject.TryGetComponent(out float speed))
        {
            var dir = (_target - position).normalized;
            var velocity = 1 * Time.deltaTime * dir;
            if (velocity.magnitude > distance)
            {
                gObject.transform.position = _target;
                return true;
            }
            else
            {
                var newPosition = position + velocity;
                gObject.transform.position = newPosition;
                return false;
            }
        }
        return true;
    }

    public override BaseState CheckTransition()
    {
        GameObject gObject = this.gameObject;

        //if move is done transition to action state
        var position = gObject.transform.position;
        var distance = Vector3.Distance(position, _target);
        if (distance < float.Epsilon)
        {
            return this;
        }
        else return this;
    }
}
