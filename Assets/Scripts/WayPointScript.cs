using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    [SerializeField] float moveDistance;
    float displacement;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the waypoint back and forth
        displacement += speed * Time.deltaTime;
        if(displacement > moveDistance || displacement < 0)
        {
            speed *= -1;
        }

        transform.Translate(transform.forward * speed * Time.deltaTime);

    }
}
