using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 _target;
    public MoveCommand(Vector3 target) => _target = target;

    /// <summary>
    /// Excecutes the command
    /// </summary>
    /// <param name="gObject"> The unit that runs the command </param>
    /// <returns> True if the command is completed </returns>
    public bool Execute(GameObject gObject)
    {
        var position = gObject.transform.position;
        var distance = Vector3.Distance(position, _target);
        if (distance < float.Epsilon)
        {
            return true;
        }

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

    /// <summary>
    /// Just for visual feedback in the Editor
    /// </summary>
    public void DrawGizmo(GameObject gObject)
    {
        Gizmos.DrawWireSphere(_target, 0.5f);
        Gizmos.DrawLine(gObject.transform.position, _target);
    }

}
