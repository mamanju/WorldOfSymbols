using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム停止時の処理(ポーズ、ゲームオーバー)
/// </summary>
public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private Image[] SelectButtons;

    private int buttonNum = 0;

    private bool pauseFlag = false;
    private bool gameOverFlag = false;
    private bool selectFlag = false;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    void Start() {
        player = GameObject.Find("Player");
        pauseFlag = player.GetComponent<PlayerController>().PauzeFlag;
    }

    private void Update() {
        if (Input.GetButtonDown("Option") || Input.GetKeyDown(KeyCode.L))
        {
            Pause();
        }

        

        #region 十字キー操作
        if (Input.GetButtonDown("Circle")) {
            if (!pauseFlag) {
                return;
            }
            if (buttonNum == 0) {
                Time.timeScale = 1;
                SceneController.Instance.ChangeScene(SceneController.SceneName.Title);
            } else {
                Pause();
            }
        }

    

        if (Input.GetAxis("CrossKey_H") == 0) {
            selectFlag = false;
            return;
        }

        if (selectFlag) {
            return;
        }

        if (Input.GetAxis("CrossKey_H") < 0) {
            if (buttonNum - 1 < 0) {
                
                buttonNum = 1;
            } else {
                
                buttonNum--;
            }
        } else {
            if (buttonNum + 1 > 1) {
                
                buttonNum = 0;
            } else {
                
                buttonNum++;
            }
        }
        if (buttonNum == 0) {
            SelectButtons[buttonNum].transform.localScale = new Vector2(1.2f, 1.2f);
            SelectButtons[buttonNum + 1].transform.localScale = new Vector2(1f, 1f);
        } else {
            SelectButtons[buttonNum].transform.localScale = new Vector2(1.2f, 1.2f);
            SelectButtons[buttonNum - 1].transform.localScale = new Vector2(1f, 1f);
        }
        #endregion
        selectFlag = true;
    }

    /// <summary>
    /// ポーズ
    /// </summary>
    public void Pause() {
        if (!pauseFlag) {
            pauseFlag = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        } else {
            pauseFlag = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver() {
        if (!gameOverFlag) {
            gameOverFlag = true;
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        } else {
            gameOverFlag = false;
            gameOverUI.SetActive(false);
        }
        
    }
}
