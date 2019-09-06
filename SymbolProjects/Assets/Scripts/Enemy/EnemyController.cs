﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// エネミーコントローラー
/// </summary>
public class EnemyController : EnemyManager
{
    private string key_Health = "Health";
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// 攻撃処理
    /// </summary>
    public void Attacking() {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine() {
        AttackFlag = true;
        yield return new WaitForSeconds(1f);
        AttackFlag = false;
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage"></param>
    public GameObject Damage(int damage)
    {
        if (Health - damage <= 0)
        {
            anim.SetInteger(key_Health, 0);
            DropCrystal();
            Enemy_SoundManager.instance.PlaySE_enemy(1);
            if (SceneManager.GetActiveScene().name == ("Tutorial"))
            {
                TutorialController.instance.EnemyDown = true;
            }
            Destroy(gameObject);
            return gameObject;
        }
        Health -= damage;
        Enemy_SoundManager.instance.PlaySE_enemy(0);
        anim.SetTrigger("Damage");
        return null;
    }

    /// <summary>
    /// クリスタルドロップ
    /// </summary>
    private void DropCrystal() {
        string path = "Prefabs/Crystal/MCrystal/Prefab/MCrystal_" + crystal;
        GameObject cry = Instantiate(Resources.Load<GameObject>(path), transform);
        cry.transform.localPosition = new Vector3(0,0,0);
        cry.transform.SetParent(transform.parent);
        Debug.Log(transform.position);
        Debug.Log("local" + transform.localPosition);
        cry.transform.localScale = new Vector3(1, 1, 1);
        cry.GetComponent<CapsuleCollider>().enabled = false;
    }
}
