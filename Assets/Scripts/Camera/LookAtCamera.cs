using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CameraMode
{
    Forward,
    LookAt
}

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private CameraMode cameraMode;
    private void LateUpdate()
    {
        switch (cameraMode)
        {
            case CameraMode.Forward:
                transform.forward = Camera.main.transform.forward;
                break;
            case CameraMode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
        }
    }
}
