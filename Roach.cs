using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roach : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider mainCollider;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCoolDown;
    [SerializeField] private float jumpChance;
    private Player player;
    private bool canJump = true;
    private float jumpRoll;

    private void Start()
    {
        canJump = true;
        jumpRoll = 100.0f;
        InvokeRepeating("JumpRoller", 0, .5f);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed * Time.deltaTime);
        if(jumpRoll < jumpChance && canJump)
        {
            rb.AddForce(transform.up * jumpForce);
            StartCoroutine(JumpCoolDown());
        }

        anim.SetFloat("YPos", transform.position.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            if(player != null) { player.TakeDamage(damage); }
            rb.useGravity = false;
            mainCollider.isTrigger = true;
        }
    }

    private void JumpRoller()
    {
        jumpRoll = Random.Range(0.0f, 100.0f);
    }

    IEnumerator JumpCoolDown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCoolDown);
        canJump = true;
    }
}
