using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class MouseInteraction : MonoBehaviour
{
    private void Update()
    {
        
        if(Input.GetMouseButtonUp(1))
        {
            CastRay();
        }

    }

    private void CastRay()
    {
      
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 150))
        {
            var pickableObject = hit.collider.gameObject.GetComponent<IInteractable>();
            if (pickableObject != null)
            {
                pickableObject.Interact();
            }
        }
        
    }
}
