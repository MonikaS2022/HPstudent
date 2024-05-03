using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseBehaviour : MonoBehaviour
{
    [Header("Mouse Information")]
    [SerializeField] GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //GetMouseInWorld();

    }
    private static GameObject GetMouseOver()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, float.MaxValue))
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    public Vector3 GetMouseInWorld()
    {
        var mousePos = Input.mousePosition;
        var mouseRay = Camera.main.ScreenPointToRay(mousePos);
        var groundPlane = new Plane(Vector3.up, Vector3.up);
        if (groundPlane.Raycast(mouseRay, out float distance))
        {
            var point = mouseRay.GetPoint(distance);
            //Debug.Log(point);
            return point;
        }
        return Vector3.zero;
    }

    //public bool UnitSelected() => _selectedUnit != null;


}
