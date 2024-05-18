using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class M_PlayerAttack : MonoBehaviour
{
    bool canAttack = true;

    [SerializeField] float attackSpeed = 2f;
    [SerializeField] GameObject prefab;

    [SerializeField] LayerMask layer;
    [SerializeField] Camera cam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Survival.Instance.inMinigame1 || !canAttack)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            M_Projectile projectile = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<M_Projectile>();
            projectile.UpdateForward(GetMouseRay());

            canAttack = false;
            StartCoroutine(AttackSpeed(attackSpeed));
        }
    }

    IEnumerator AttackSpeed(float attackTimer)
    {
        yield return new WaitForSeconds(attackTimer);

        canAttack = true;
    }

    public Vector3 GetMouseRay()
    {
        Vector3 mouse = Input.mousePosition;

        Ray castPoint = cam.ScreenPointToRay(mouse);
        RaycastHit hit;


        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, layer))
        {
            Vector3 newHit = hit.point;
            newHit.y = 0;
            return newHit;
        }
        return Vector3.zero;

    }
}
