﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Guide : MonoBehaviour
{
    private TextMesh guideText;

    private GameObject growTree;
    private int growCount;

    private string[] guide = new string[5];

    void Start()
    {
        GuideSentence();
        guideText = GetComponent<TextMesh>();
        transform.localScale = new Vector3(-1, 1, 1);
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void GuideSentence()
    {
        guide[0] = "この木は斧を使えば切れそうだ";
        guide[1] = "近づくと登れそうだ";
        guide[2] = "あのクリスタルは槍を使えば破壊出来そうだ";
        guide[3] = "あと" + growCount.ToString() + "回シンバルをたたくと\n木が成長しそうだ";
        guide[4] = "";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FallTreeGuide")
        {
            guideText.text = guide[0];
        }

        if (other.tag == "ClimbTree")
        {
            guideText.text = guide[1];
        }

        if (other.tag == "FireSwitch")
        {
            guideText.text = guide[2];
        }

        if (other.name == "nae")
        {
            growTree = other.transform.parent.gameObject;
            growCount = 3 - growTree.GetComponent<GrowTreeController>().GrowCount;
            GuideSentence();
            guideText.text = guide[3];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        guideText.text = guide[4];
    }
}
