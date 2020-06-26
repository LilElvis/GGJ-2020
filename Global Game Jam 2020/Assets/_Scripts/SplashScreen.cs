using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private AudioSource mainSource;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }
    
    public void playStretchySound()
    {
        print("Play Now");
        mainSource.Play();
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(6.0f);

        SceneManager.LoadScene("MainMenu");
    }
}
