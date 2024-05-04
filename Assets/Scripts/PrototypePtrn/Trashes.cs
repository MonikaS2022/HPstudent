using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashes : MonoBehaviour, IClonable
{
 
    public IClonable Clone()
    {
        Trashes trashes = Instantiate(this);
        trashes.transform.position = new Vector3(Random.Range(-4.0f, 8.0f), 0.01f, Random.Range(5.0f, -12.0f));//random position
        this.gameObject.SetActive(true);
        return trashes;
    }

}
