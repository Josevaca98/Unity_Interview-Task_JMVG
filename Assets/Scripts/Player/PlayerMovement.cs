using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //The speed the player moves.
    public float moveSpeed = 5;
    //Reference to the RigidBody Component.
    public Rigidbody2D rb;
    //Reference to the Animator Component.
    public Animator animator;
    // Vector2 to store movement input from the player.
    Vector2 movement;
    // Reference to the notification sign GameObject.
    [SerializeField] private GameObject notificationSign;

    // Reference to the instructions panel GameObject.
    public GameObject instructionsPanel;

    private void Start() 
    {
         // Initially disable the notification sign.
        EnableDisableNotificationSign(false);
    }

    // Method to enable or disable the notification sign.
    public void EnableDisableNotificationSign(bool enabled)
    {
        notificationSign.SetActive(enabled);
    }

    void FixedUpdate() 
    {   
        // Check if the instructions panel is not active.
        if(!instructionsPanel.activeInHierarchy)
        {
            movement = Vector2.zero;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            // Update animation and move the character.
            UpdateAnimationAndMove();
        }
    }

    // Method to update animation based on player movement.
    void UpdateAnimationAndMove()
    {
        if (movement != Vector2.zero)
        {
            // Move the character and set animation parameters.
            MoveCharacter();
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetBool("Moving", true);
        }
        else
        {
             // If there is no movement, set the "Moving" parameter to false.
            animator.SetBool("Moving", false);
        }
    }

    // Method to move the character based on player input.
    void MoveCharacter()
    {
        // Move the character's position based on the calculated movement vector.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
