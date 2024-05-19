using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasCollided : MonoBehaviour
{
    [SerializeField] int increaseHunger = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bowl")
        {
            other.gameObject.GetComponent<M_Enemy>().health = 0;
            Survival.Instance.IncreaseHunger(increaseHunger);
        }

        if (other.gameObject.tag == "M2_Plane")
        {
            other.gameObject.GetComponent<M_Enemy>().health = 0;
        }
    }
}