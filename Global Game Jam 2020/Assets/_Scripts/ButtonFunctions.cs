using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void OnClick_LoadScene(string aSceneName)
    {
        SceneManager.LoadScene(aSceneName, LoadSceneMode.Single);
    }

    public void OnClick_Activate(GameObject aGameObject)
    {
        aGameObject.SetActive(true);
    }

    public void OnClick_Deactivate(GameObject aGameObject)
    {
        aGameObject.SetActive(false);
    }

    public void OnClick_Quit()
    {
        Application.Quit();
    }
}
