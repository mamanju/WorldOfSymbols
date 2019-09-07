using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 木を登る処理
/// </summary>
public class ClimbTreeController : MonoBehaviour
{
    [SerializeField]
    private float fadeStartTime;

    [SerializeField]
    private GameObject climbPos;

    private bool climbFlag = false;

    public bool ClimbFlag
    {
        get { return climbFlag; }
        set { climbFlag = value; }
    }

    /// <summary>
    /// 木を登る
    /// </summary>
    public void Climb(GameObject player)
    {
        Debug.Log("call");
        // StartCoroutine(ClimbCoroutine(player));
        if (!climbFlag)
        {
            StartCoroutine(ClimbCoroutine(player));
        }
    }

    private IEnumerator ClimbCoroutine(GameObject player)
    {
        climbFlag = true;
        player.GetComponent<PlayerController>().MoveFlag = false;

        // 再生から指定された時間後、フェードイン
        FadePanelManager.instance.FadeIn();
        yield return new WaitForSecondsRealtime(fadeStartTime);
        player.transform.position = climbPos.transform.position;
        FadePanelManager.instance.FadeOut();
        yield return new WaitForSecondsRealtime(fadeStartTime);
        climbFlag = false;
        player.GetComponent<PlayerController>().MoveFlag = true;

        yield return null;
    }
}
