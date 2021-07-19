using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileMenu : MonoBehaviour {

    public GameObject DialogBox;
    public GameObject ProfileUI;

    public void BackHome()
    {
        SceneManager.LoadScene(0);
    }

    public void CTFDialog()
    {
        DialogBox.SetActive(false);
        ProfileUI.SetActive(true);
    }
}
