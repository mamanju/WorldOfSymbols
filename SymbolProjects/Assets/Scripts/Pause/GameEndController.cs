using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    // Start is called before the first frame update
    void Update() {
        if (Input.GetButtonDown("Circle")) {
            SceneController.Instance.ChangeScene(SceneController.SceneName.Title);
        }
    }
}
