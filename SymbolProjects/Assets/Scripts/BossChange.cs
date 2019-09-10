using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChange : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerController>()) {
            player.MoveFlag = false;
            SceneController.Instance.ChangeScene(SceneController.SceneName.BossStage);
        }
    }
}
