using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControl : MonoBehaviour
{

    public GameObject fadeEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fadeEffect.SetActive(true);
        }
    }
}
