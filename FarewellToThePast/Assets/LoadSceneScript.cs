using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    public void LoadScene() {
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneNumber) {
        SceneManager.LoadScene(sceneNumber);
    }
}
