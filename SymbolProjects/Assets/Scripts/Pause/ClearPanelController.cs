using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPanelController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Circle")) {
            SceneController.Instance.ChangeScene(SceneController.SceneName.Title);
        }
    }
}
