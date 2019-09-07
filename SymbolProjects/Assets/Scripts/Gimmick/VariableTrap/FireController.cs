using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Time.deltaTime * rotateSpeed;
        float offsetX = rend.material.GetTextureOffset("_MainTex").x;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX + speed, 0));

    }

    public void OnCollisionEnter(Collision col) {
        if (col.gameObject.GetComponent<PlayerStatus>()) {
            col.gameObject.GetComponent<PlayerStatus>().DownHP(1);
        }
    }
}
