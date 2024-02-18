using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://discussions.unity.com/t/how-do-i-make-the-camera-zoom-in-and-out-with-the-mouse-wheel/36739/2
 * https://stackoverflow.com/questions/43187019/moving-camera-around-an-object-in-unity
 */
public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    

    public float pitch = 2f;
    public float yawSpeed = 100f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
