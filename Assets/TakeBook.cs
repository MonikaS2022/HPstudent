using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TakeBook : MonoBehaviour, IPointerClickHandler

    
{
    bool isTaken = false;
    public Animator animator;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        isTaken = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isTaken", isTaken);
    }
}
