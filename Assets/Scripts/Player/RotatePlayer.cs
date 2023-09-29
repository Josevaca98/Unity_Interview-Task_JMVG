using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    // Reference to the Animator component.
    private Animator anim;
    // Array to store four cardinal positions for sprite rotation.
    private Vector2[] positions;
    // Index representing the current position in the positions array.
    private int currentPosition;

    void Start()
    {
        // Initialize the Animator component.
        anim = GetComponent<Animator>();
        // Set up the established positions.
        EstablishedPositions();
    }

    // Method to initialize the array with cardinal positions.
    void EstablishedPositions()
    {
        positions = new Vector2[4];

        positions[0] = new Vector2(0, -1); //Down
        positions[1] = new Vector2(-1, 0); //Left
        positions[2] = new Vector2(1, 0);  //Right
        positions[3] = new Vector2(0, 1);  //Up
    }

    // Method to rotate the sprite to the left.
    public void RotateToLeft()
    {
        // Check if there is a position to the left.
        if (currentPosition < positions.Length - 1)
            currentPosition++;
        else
        // Wrap around to the first position if at the end
            currentPosition = 0;

        // Update the sprite position based on the new current position.
        UpdatePosition();
    }

    // Method to rotate the sprite to the right.
    public void RotateToRight()
    {
        // Check if there is a position to the right.
        if (currentPosition > 0)
            currentPosition--;
        else
        // Wrap around to the last position if at the beginning.
            currentPosition = positions.Length - 1;
        // Update the sprite position based on the new current position.
        UpdatePosition();
    }

    // Method to update the sprite's position in the Animator.
    private void UpdatePosition()
    {
        // Set Animator parameters for horizontal and vertical positions.
        anim.SetFloat("Horizontal", positions[currentPosition].x);
        anim.SetFloat("Vertical", positions[currentPosition].y);
    }
}
