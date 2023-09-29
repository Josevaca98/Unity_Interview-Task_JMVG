using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // A boolean indicating whether the interactable object is in range for interaction.
    public bool isInRange;
    // The key that triggers the interaction.
    public KeyCode key;
    // UnityEvent to be invoked when the interaction occurs.
    public UnityEvent interactAction;
    // Reference to the GameObject associated with this script.
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
         // Check if the object is in range and the specified key is pressed.
        if(isInRange)
        {
            if(Input.GetKeyDown(key))
            {
                 // Invoke the interaction action.
                interactAction.Invoke();
            }
        }
    }


    // Called when another collider enters the trigger zone.
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // Check if the entering collider belongs to the "Player" tag.
        if(collision.gameObject.CompareTag("Player"))
        {
            // Set isInRange to true and provide feedback.
            isInRange = true;
            // Enable the notification sign for the player.
            collision.gameObject.GetComponent<PlayerMovement>().EnableDisableNotificationSign(true);
        }
    }

    // Called when another collider exits the trigger zone.
    private void OnTriggerExit2D(Collider2D collision) 
    {
        // Check if the exiting collider belongs to the "Player" tag.
        if(collision.gameObject.CompareTag("Player"))
        {
            // Set isInRange to false and provide feedback.
            isInRange = false;

            // Disable the notification sign for the player.
            collision.gameObject.GetComponent<PlayerMovement>().EnableDisableNotificationSign(false);

            // Deactivate the associated GameObject.
            obj.SetActive(false);
        }
    }
}
