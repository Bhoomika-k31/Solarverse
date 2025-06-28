using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneNameToLoad = "UniverseScene";

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
