using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    [SerializeField] private GameObject notificationSign;

    public GameObject instructionsPanel;

    private void Start() 
    {
        EnableDisableNotificationSign(false);
    }

    public void EnableDisableNotificationSign(bool enabled)
    {
        notificationSign.SetActive(enabled);
    }

    void FixedUpdate() 
    {   
        if(!instructionsPanel.activeInHierarchy)
        {
            movement = Vector2.zero;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            UpdateAnimationAndMove();
        }
    }

    void UpdateAnimationAndMove()
    {
        if (movement != Vector2.zero)
        {
            MoveCharacter();
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
