using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloningTrashes : MonoBehaviour
{
    public Trashes trashes;
    float passed = 10f; //implement time when trashes are added
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        passed-= Time.deltaTime;
        if(passed < 0)
        {
            passed = 10f;
            Trashes trashesCloned = (Trashes)CloneFactory.instance.GetClone(trashes);
        }

        /*
        Debug.Log("key A is up");
        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("key A is up");
            Trashes trashesCloned = (Trashes)CloneFactory.instance.GetClone(trashes);
           //Debug.Log("key A is up");
            Debug.Log(trashesCloned.name);
            
        }*/
    }
}
