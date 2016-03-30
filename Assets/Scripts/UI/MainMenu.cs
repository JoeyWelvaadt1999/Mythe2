using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SceneLoader(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
