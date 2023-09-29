using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode key;
    public UnityEvent interactAction;
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(key))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Estoy adentro");
            collision.gameObject.GetComponent<PlayerMovement>().EnableDisableNotificationSign(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Estoy afuera");

            collision.gameObject.GetComponent<PlayerMovement>().EnableDisableNotificationSign(false);

            obj.SetActive(false);
        }
    }
}
