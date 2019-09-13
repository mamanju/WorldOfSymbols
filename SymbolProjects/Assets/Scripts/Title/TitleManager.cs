using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルマネージャー
/// </summary>
public class TitleManager : MonoBehaviour
{
    private void Start() {
        Time.timeScale = 1;
        SceneController.Instance.ChangeFlag = false;
    }

    private void Update() {
        if (Input.GetButtonDown("Circle") || Input.GetKeyDown(KeyCode.O)) {
            MoveSelect();
        }
    }
    /// <summary>
    /// ステージセレクトへ遷移
    /// </summary>
    public void MoveSelect() {
        if (SceneController.Instance.ChangeFlag) { return; }
        SceneController.Instance.ChangeFlag = true;
        SceneController.Instance.ChangeScene(SceneController.SceneName.Tutorial);
    }
}
