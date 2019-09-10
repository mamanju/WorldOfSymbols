using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanelManager : SingletonMonoBehaviour<FadePanelManager>
{
    // アルファ値
    private float alfa;

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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
            FadeIn();
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            FadeOut();
        }
    }

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
        Debug.Log("InStart" + GetComponent<CanvasGroup>().alpha);
        while(alfa < 1)
        {
            Debug.Log("In" + GetComponent<CanvasGroup>().alpha);
            GetComponent<CanvasGroup>().alpha += 0.03f;
            alfa += 0.03f;
            yield return null;
        }
        GetComponent<CanvasGroup>().alpha = 1f;
        Debug.Log("In終了" + GetComponent<CanvasGroup>().alpha);
        yield return new WaitForSeconds(2f);
    }

    /// <summary>
    /// フェードアウトコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOutCoroutine()
    {
        Debug.Log("OutStart" + GetComponent<CanvasGroup>().alpha);
        while (alfa >= 0)
        {
            Debug.Log("Out" + GetComponent<CanvasGroup>().alpha);
            alfa -= 0.03f;
            GetComponent<CanvasGroup>().alpha -= 0.03f;
            yield return null;
        }
        GetComponent<CanvasGroup>().alpha = 0f;
        Debug.Log("Out終了" + GetComponent<CanvasGroup>().alpha);
        yield return new WaitForSeconds(2f);
    }
}
