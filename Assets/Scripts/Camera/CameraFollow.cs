using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    [Header("玩家与相机偏移")]
    public Vector3 offset;         // 相机与玩家的偏移量
    public float smoothSpeed = 0.125f;  // 相机平滑移动的速度

    void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position;   // 计算目标位置
        Vector3 tagetPosition = new Vector3(desiredPosition.x, desiredPosition.y, 1) - offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, tagetPosition, smoothSpeed);  // 平滑移动到目标位置
        transform.position = smoothedPosition;  // 更新相机位置

        transform.LookAt(player.transform);  // 可选：使相机始终朝向玩家
    }

}
