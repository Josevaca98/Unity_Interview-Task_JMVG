using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private Animator anim;
    private Vector2[] positions;
    private int currentPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        EstablishedPositions();
    }

    void EstablishedPositions()
    {
        positions = new Vector2[4];

        positions[0] = new Vector2(0, -1); //Down
        positions[1] = new Vector2(-1, 0); //Left
        positions[2] = new Vector2(1, 0);  //Right
        positions[3] = new Vector2(0, 1);  //Up
    }

    public void RotateToLeft()
    {
        if (currentPosition < positions.Length - 1)
            currentPosition++;
        else
            currentPosition = 0;

        UpdatePosition();
    }

    public void RotateToRight()
    {
        if (currentPosition > 0)
            currentPosition--;
        else
            currentPosition = positions.Length - 1;

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        anim.SetFloat("Horizontal", positions[currentPosition].x);
        anim.SetFloat("Vertical", positions[currentPosition].y);
    }
}
