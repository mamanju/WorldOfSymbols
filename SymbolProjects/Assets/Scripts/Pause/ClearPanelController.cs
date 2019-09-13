using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPanelController : MonoBehaviour
{
    // Update is called once per frame

    private void Start() {
        SceneController.Instance.ChangeFlag = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Circle")) {
            if (SceneController.Instance.ChangeFlag) { return; }
            SceneController.Instance.ChangeFlag = true;
            SceneController.Instance.ChangeScene(SceneController.SceneName.Title);
        }
    }
}
