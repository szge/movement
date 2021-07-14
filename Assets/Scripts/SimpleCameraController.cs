using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public Vector3 cameraOffset;
    public Transform player;
    public float playerHeadHeight;
    public float sensitivity;

    public void Start()
    {
        transform.position = player.position + cameraOffset;
        transform.LookAt(player.position + Vector3.up * playerHeadHeight);
    }

    public void Update()
    {
        transform.rotation = Quaternion.Euler((Vector3.up * Input.GetAxis("Mouse X") + Vector3.left * Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime) * transform.rotation;
        transform.position = transform.rotation * (player.position + cameraOffset);
    }
} 