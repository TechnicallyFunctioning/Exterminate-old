using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundCheckMask;
    public int health;
    public bool gameOver = false;
    public float timeSurvived = 0;
    public int score;
    private bool canJump;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump) { Jump(); }
#endif
        if (IsGrounded()) { anim.SetBool("grounded", true); } else { anim.SetBool("grounded", false); }
        if(health <= 0) { Die(); }
        SurvivalTimer();
    }

    public void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (!IsGrounded())
            {
                canJump = false;
            }
        }
    }

    private bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundCheckMask))
        {
            canJump = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void Die()
    {
        Time.timeScale = 0;
        gameOver = true;
    }

    private void SurvivalTimer()
    {
        timeSurvived += Time.deltaTime;
    }
}
