using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    bool Execute(GameObject gObject);

    void DrawGizmo(GameObject gObject);


}
