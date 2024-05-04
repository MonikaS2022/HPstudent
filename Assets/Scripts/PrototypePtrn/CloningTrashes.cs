using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloningTrashes : MonoBehaviour
{
    public Trashes trashes;
    float passed = 2f; //implement time when trashes are added
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.A))
        {
           Trashes trashesCloned = (Trashes)CloneFactory.instance.GetClone(trashes);
           Debug.Log("key A is up");
            Debug.Log(trashesCloned.name);
            
        }
    }
}
