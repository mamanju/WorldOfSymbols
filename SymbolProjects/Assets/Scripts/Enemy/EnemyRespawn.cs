using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    private EnemyManager eManager;

    private bool isSpawn = false;

    private string monsterPath = "Prefabs/Enemies/Slime";

    private string pare = "_Parent";

    private float timer;

    [SerializeField]
    private float spawmTime;

    public bool setIsSpawn {
        set { isSpawn = value; }
    }

    void Start() {
        isSpawn = false;
        eManager = transform.parent.GetComponentInChildren<EnemyController>();
    }

    void Update() {
        if (!isSpawn) {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= spawmTime) {
            ReSpawn();
        }
    }

    public void ReSpawn() {
        string path = "";
        switch (eManager.crystal) {
            case EnemyManager.Crystals.Circle: // Blue
                path = monsterPath + "Blue" + pare;
                break;
            case EnemyManager.Crystals.LessThan: // Yellow
                path = monsterPath + "Yellow" + pare;
                break;
            case EnemyManager.Crystals.Stick: // Green
                path = monsterPath + "Green" + pare;
                break;
            case EnemyManager.Crystals.Triangle: // Red
                path = monsterPath + "Rad" + pare;
                break;
            default:
                break;
        }
        GameObject monster = new GameObject();
        monster = Resources.Load(path) as GameObject;
        Instantiate(monster,transform.position,Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
