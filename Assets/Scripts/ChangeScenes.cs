using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(WaitForSceneToChange(sceneName, 1.5f));
    }

     public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitForSceneToChange(string sceneName, float seconds = 0)
    {
        anim.SetBool("fadeOut", true);
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
}
