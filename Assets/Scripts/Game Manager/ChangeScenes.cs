using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    //Animator Reference.
    [SerializeField] private Animator anim;

    //Method to Use in buttons to change scene.
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(WaitForSceneToChange(sceneName, 1.5f));
    }

    //Method to Quit the game on the Executable.
     public void Quit()
    {
        Application.Quit();
    }

    //A method to wait for some time and play an animation to smooth the change of the scene.
    IEnumerator WaitForSceneToChange(string sceneName, float seconds = 0)
    {
        anim.SetBool("fadeOut", true);
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
}
