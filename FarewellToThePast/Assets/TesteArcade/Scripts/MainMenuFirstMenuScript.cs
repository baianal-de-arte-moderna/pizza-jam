using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFirstMenuScript : MonoBehaviour
{
    public GameObject secondMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            secondMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
