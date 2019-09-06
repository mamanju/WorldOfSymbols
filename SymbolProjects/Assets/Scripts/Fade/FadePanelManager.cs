﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanelManager : SingletonMonoBehaviour<FadePanelManager>
{
    // アルファ値
    private float alfa;

    [SerializeField]
    private Image FadePanel; 

    #region Singleton
    public static FadePanelManager instance;
    public static FadePanelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (FadePanelManager)FindObjectOfType(typeof(FadePanelManager));

                if (instance == null)
                {
                    Debug.LogError(typeof(FadePanelManager) + "is nothing");
                }
            }

            return instance;
        }
    }
    void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    /// <summary>
    /// フェードイン
    /// </summary>
    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    /// <summary>
    /// フェードインコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeInCoroutine()
    {
        FadePanel.gameObject.SetActive(true);
        
        while(alfa < 1)
        {
            FadePanel.color += new Color(0, 0, 0, 0.01f);
            alfa += 0.01f;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }

    /// <summary>
    /// フェードアウトコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOutCoroutine()
    {
        while (alfa >= 0)
        {
            FadePanel.color -= new Color(0, 0, 0, 0.01f);
            alfa -= 0.01f;
            yield return null;
        }
    }
}
