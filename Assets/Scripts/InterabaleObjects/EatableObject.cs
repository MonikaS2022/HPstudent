using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObject : MonoBehaviour, IInteractable

{
  public string objectName;
  public void Interact()
  {
        Survival.Instance.IncreaseHunger(50);
        this.gameObject.SetActive(false);
    }
}

