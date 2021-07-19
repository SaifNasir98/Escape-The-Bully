﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour {

    public GameObject loadingScreenObj;
    public Slider slider;

    AsyncOperation async;

    public void LoadScreen()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress ==  0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
