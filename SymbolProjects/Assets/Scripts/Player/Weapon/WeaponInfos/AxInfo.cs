﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxInfo : WeaponController
{
    public static int attack;
    public static int weaponID;

    private GameObject player;
    void Start()
    {
        // 斧の基本情報
        attack = 3;
        durable = 5;
        durable_max = 5;
        weaponID = 2;

        player = transform.parent.GetComponent<GetPlayer>().Player;
    }

    public void DelWeaponDurable()
    {
        Debug.Log("durable=" + durable);
        if (durable <= 0) { return; }
        base.BreakWeaponCheck(1);
        if (durable == 0)
        {
            player.GetComponent<PlayerController>().WeaponChangeLeft();
            player.GetComponent<WeaponManager>().DeleteWeapon(weaponID - 1);
            durable = durable_max;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerController>().Attack(other.gameObject);
    }
}
