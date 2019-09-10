using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private static int hp = 20;

    [SerializeField]
    private GameObject gameOverImage;
    [SerializeField]
    private GameObject gameClearImage;
    [SerializeField]
    private GameObject UISet;
    [SerializeField]
    private GameObject minimap;

    public GameObject UISET {
        get { return UISet; }
        set { UISet = value; }
    }
    public GameObject Minimap {
        get { return minimap; }
        set { minimap = value; }
    }

    public GameObject GameClearImage {
        get { return gameClearImage; }
        set { gameClearImage = value; }
    }

    public static int PlayerHp()
    {
        return hp;
    }

    private int max_hp = 20;
    private int attack = 1;
    private KnockBack knockBack;
    private PlayerController pCon;

    private int nowAttack;
    private int nowWeaponID;
    public int NowWeaponID
    {
        get { return nowWeaponID; }
    }
    private int[] weaponAttacks = new int[10];
    

    public int PlayerMax_Hp()
    {
        return max_hp;
    }

    public int PlayerAttack()
    {
        return nowAttack;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "StageFirst"
            || SceneManager.GetActiveScene().name == "Tutorial")
        {
            hp = max_hp;
        }
        weaponAttacks[0] = 1 + attack;
        weaponAttacks[1] = 2 + attack;
        weaponAttacks[2] = 3 + attack;
        weaponAttacks[3] = -1 + attack;
        weaponAttacks[5] = -1 + attack;

        nowAttack = weaponAttacks[0];
    }

    private void Update()
    {
        if (hp != 0) { return; }
        
        //ゲームオーバーの処理
    }

    public void WeaponAttack(int _attack)
    {
        nowAttack = weaponAttacks[_attack];
        nowWeaponID = _attack;
    }


    //HP減少
    public void DownHP(int _damage)
    {
        pCon = GetComponent<PlayerController>();
        if (pCon.ShildFlag) { return; }
        Player_SoundManager.instance.PlaySE_player(3);
        if (hp - _damage <= 0) {
            gameOverImage.GetComponent<PauseController>().GameOver();
            UISet.SetActive(false);
            if (minimap != null) {
                minimap.SetActive(false);
            }
            Time.timeScale = 0;
            return;
        }

        hp -= _damage;
        
        //if(hp <= 0)
        //{
        //    gameOverImage.GetComponent<PauseController>().GameOver();
        //    UISet.SetActive(false);
        //    if(minimap != null) {
        //        minimap.SetActive(false);
        //    }
        //    Time.timeScale = 0;
        //}
        knockBack = GetComponent<KnockBack>();
        knockBack.Knockback();
    }
}