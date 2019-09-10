using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystalController : MonoBehaviour
{
    private GameObject clearPanel;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        clearPanel = GameObject.FindObjectOfType<PlayerStatus>().gameObject;
        clearPanel.GetComponent<PlayerStatus>().GameClearImage.SetActive(true);
        clearPanel.GetComponent<PlayerStatus>().UISET.SetActive(false);
        clearPanel.SetActive(true);
    }
}
