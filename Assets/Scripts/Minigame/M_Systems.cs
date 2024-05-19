using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class M_Systems : MonoBehaviour
{

    public virtual void StartGame()
    {

    }

    public virtual void StopGame()
    {
        Survival.Instance.inMinigame = false;
    }

}
