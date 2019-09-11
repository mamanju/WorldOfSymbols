﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    private PauseController pauzePanel;

    void Start() {
        pauzePanel = transform.parent.GetComponent<PauseController>();
    }
    // Start is called before the first frame update
    void Update() {
        if (Input.GetButtonDown("Circle")) {
            Time.timeScale = 1;
            SceneController.Instance.ChangeScene(SceneController.SceneName.Title);
        }
    }
}
