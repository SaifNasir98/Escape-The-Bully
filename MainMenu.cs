using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject QuitDialogBox;

	public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Store()
    {
        SceneManager.LoadScene(2);
    }

    public void ProfileMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        QuitDialogBox.SetActive(true);
    }
}
