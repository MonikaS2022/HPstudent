using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasCollided : MonoBehaviour
{
    [SerializeField] int increaseHunger = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bowl")
        {
            gameObject.GetComponent<M_Enemy>().health = 0;
            Survival.Instance.IncreaseHunger(increaseHunger);
        }

        if (other.gameObject.tag == "M2_Plane")
        {
            gameObject.GetComponent<M_Enemy>().health = 0;
        }
    }
}
