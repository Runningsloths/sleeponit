using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    [Header("Tracking Player")]
    [Range(5f, 15f)]
    [Tooltip("The higher the percentage, the faster the camera catches up to the object")]
    public float cameraEase;
    public Vector3 cameraOffset;

    [Header("Zoom")]
    [Range(0.01f, 0.09f)]
    public float zoomSensitivity;
    public float zoomEase;
    [Space()]
    public float minFOV;
    public float maxFOV;

    private float deltaScroll;
    private float desiredFOV;
    private PlayerInput inputActions;
    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
        desiredFOV = cam.fieldOfView;
    }
    void Awake() {
        inputActions = new PlayerInput();
        inputActions.Player.Scroll.performed += ctx => deltaScroll = ctx.ReadValue<float>();
    }
    void Update() {
        // Zoom Set
        if (deltaScroll != 0)
        {
            desiredFOV = Mathf.Clamp(cam.fieldOfView - deltaScroll * zoomSensitivity, minFOV, maxFOV);
        }
    }
    void FixedUpdate()
    {
        // Delayed Camera
        transform.position = Vector3.Lerp(transform.position, player.position + cameraOffset, cameraEase * Time.deltaTime);
        // Zoom
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, desiredFOV, zoomEase * Time.deltaTime);
    }
    private void OnEnable() 
    {
        inputActions.Enable();
    }
    private void OnDisable() 
    {
        inputActions.Disable();
    }
}