using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    bool doOnce;
    
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
                StartCoroutine(WaitForSceneToChange("Main Menu", 1.5f));
    }

    IEnumerator WaitForSceneToChange(string sceneName, float seconds = 0)
    {
        anim.SetBool("fadeOut", true);
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
}
