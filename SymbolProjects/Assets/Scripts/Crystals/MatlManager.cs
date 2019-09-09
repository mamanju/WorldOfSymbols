﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatlManager : MonoBehaviour
{
    private static int[] nowMatl = new int[] { 0, 0, 0, 0 };
    public static int[] NowMatl
    {
        get { return nowMatl; }
        set { nowMatl = value; }
    }

    [SerializeField]
    private GameObject matlBoxes;

    private GameObject[] matlBox = new GameObject[4];

    private int matlCount;

    //リストの初期化
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StageFirst")
        {
            nowMatl = new int[] { 0, 0, 0, 0 };
        }

        for (int i = 0; i < matlBox.Length; i++)
        {
            matlBox[i] = matlBoxes.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        for (int i = 0; i < nowMatl.Length; i++)
        {
            if (nowMatl[i] == 0)
            {
                matlBox[i].GetComponent<MatlInfo>().matlList = MatlInfo.MatlList.empty;
            }
        }
    }

    public void HaveCrystal()
    {
        for(int i = 0; i < matlBox.Length; i++)
        {

            if(nowMatl[i] != 0)
            {
                matlBox[i].GetComponent<MatlInfo>().matlList
                    = ((MatlInfo.MatlList)Enum.ToObject(typeof(MatlInfo.MatlList), i));
            }
            else
            {
                matlBox[i].GetComponent<MatlInfo>().matlList
                    = MatlInfo.MatlList.empty;
            }
        }
    }
}
