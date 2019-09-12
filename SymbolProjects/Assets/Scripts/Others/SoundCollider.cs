using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{
    private AudioSource audio;

    void Start() {
        audio = transform.parent.GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            audio.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            audio.enabled = false;
        }
    }
}
