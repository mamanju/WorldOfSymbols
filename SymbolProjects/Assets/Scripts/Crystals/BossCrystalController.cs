using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystalController : MonoBehaviour
{
    private GameObject clearPanel;
    // Start is called before the first frame update
    void Awake()
    {
        clearPanel = GameObject.FindObjectOfType<ClearPanelController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {

    }
}
