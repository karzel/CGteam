﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneName = "GameStage";
    public static Title instance;
    private SaveAndLoad theSNL;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    public void ClickStart()
    {
        Debug.Log("로딩");
        SceneManager.LoadScene(sceneName);
    }

    public void ClickLoad()
    {
        StartCoroutine(LoadCoroutine());
    }    

    IEnumerator LoadCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while(!operation.isDone)
            yield return null;
        theSNL = FindObjectOfType<SaveAndLoad>();
        theSNL.LoadData();
        Destroy(gameObject);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
