using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 5.0f;

    public float smoothing = 2.0f;

    public GameObject character;

    private Vector2 mouseMove;

    private Vector2 smoothMouseMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var cameraVector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        cameraVector = Vector2.Scale(cameraVector, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothMouseMove.x = Mathf.Lerp(smoothMouseMove.x, cameraVector.x, 1f / smoothing);

        smoothMouseMove.y = Mathf.Lerp(smoothMouseMove.y, cameraVector.y, 1f / smoothing);

        mouseMove += smoothMouseMove;

        transform.localRotation = Quaternion.AngleAxis(-mouseMove.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseMove.x, character.transform.up);
    }
}
