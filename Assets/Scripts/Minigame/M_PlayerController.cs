using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerController : MonoBehaviour
{
    //[SerializeField] GameObject dashEffect;
    [SerializeField] float movementSpeed = 10;
    [SerializeField] LayerMask layer;
    [SerializeField] Camera cam;
    public Animator anim;
    CharacterController cc;
    Vector3 input;

    public float dashCooldown = 1f;
    public float dashSpeed;
    public float dashDuration;
    bool isDashing = false;
    bool canDash = true;

    float health = 3;
    float maxHealth = 3;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Survival.Instance.inMinigame1)
        {
            return;
        }
        GatherInput();
        Animation();
        Look();

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
        
        if (!isDashing)
        {
            Move();
        }
        
    }

    private void Animation()
    {
        if (input != Vector3.zero)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        Vector3 dashDirection = (GetMouseRay() - this.transform.position).normalized;

        isDashing = true;

        //dashEffect.SetActive(true);

        while (Time.time < startTime + dashDuration)
        {

            //realtime.canTakeDamage = false;
            cc.excludeLayers = LayerMask.GetMask("Enemy");

            if (input != Vector3.zero)
            {
                cc.Move(input * dashSpeed * Time.deltaTime * movementSpeed);
            }
            else
            {
                cc.Move(dashDirection * dashSpeed * Time.deltaTime * movementSpeed);
            }

            yield return null;
        }

        //dashEffect.SetActive(false);
        cc.excludeLayers = ~Physics.AllLayers;
        isDashing = false;
        canDash = false;
        StartCoroutine(DashCooldown(dashCooldown));
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void Move()
    {
        input.y = 0;
        cc.Move(input * movementSpeed * Time.deltaTime);
        //Uncomment for smoothturn.
        //playerRigidbody.MovePosition(transform.position * input.magnitude * speed * Time.deltaTime);
    }

    public void RotateTowards(Vector3 target)
    {
        Quaternion rot = Quaternion.LookRotation((target - transform.position), Vector3.up);
        rot.z = 0f;
        rot.x = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360 * Time.deltaTime);
    }

    public IEnumerator DashCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);

        canDash = true;
    }

    private void Look()
    {
        if (input == Vector3.zero)
        {
            RotateTowards(GetMouseRay());
        }
        else
        {
            var rot = Quaternion.LookRotation(input, Vector3.up);
            rot.z = 0f;
            rot.x = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360 * Time.deltaTime);
        }
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
