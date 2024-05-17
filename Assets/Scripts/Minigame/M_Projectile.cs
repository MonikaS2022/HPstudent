using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Projectile : MonoBehaviour
{
    Vector3 orignialPosition;

    float speed = 10f;
    float maxDistance = 20f;
    float damage = 0.25f;
    void Start()
    {
        orignialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Vector3.Distance(orignialPosition, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //// Add Damage
            other.GetComponent<M_Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void UpdateForward(Vector3 target)
    {
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.forward = (target - pos).normalized;
    }
}
