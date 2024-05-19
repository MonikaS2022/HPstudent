using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneFactory : MonoBehaviour
{
    public static CloneFactory instance { get; private set; }
   

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }

        else
        {
            instance = this;
        }
       
    }
    public IClonable GetClone(IClonable sample)
    {
        return sample.Clone();
    }
   

}
