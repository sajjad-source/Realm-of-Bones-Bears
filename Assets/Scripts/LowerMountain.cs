using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerMountain : MonoBehaviour
{
    public Animator animator;
    public Camera mainCamera;
    public Camera mountainCamera;
    public AudioSource rumble;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Play());
        }
    }

    private IEnumerator Play()
    {
        mainCamera.enabled = false;
        mountainCamera.enabled = true;
        rumble.Play();
        animator.SetBool("Lower", true);
        yield return new WaitForSeconds(4);
        rumble.Pause();
        mainCamera.enabled = true;
        mountainCamera.enabled = false;
    }
}
