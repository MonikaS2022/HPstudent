using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 bias = new Vector3(1, 1, 1);

    private void Update()
    {
        transform.position = player.transform.position + bias;

    }
}
