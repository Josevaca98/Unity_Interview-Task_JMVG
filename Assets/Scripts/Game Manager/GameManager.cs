using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Reference the Animator Component.
    [SerializeField] private Animator anim;
    
    void Update()
    {
        //If the Escape Key is Pressed it returns to the Main Menu Scene.
            if (Input.GetKeyDown(KeyCode.Escape))
                StartCoroutine(WaitForSceneToChange("Main Menu", 1.5f));
    }

    //A Method to Wait an animation and then change Scene.
    IEnumerator WaitForSceneToChange(string sceneName, float seconds = 0)
    {
        anim.SetBool("fadeOut", true);
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
}
