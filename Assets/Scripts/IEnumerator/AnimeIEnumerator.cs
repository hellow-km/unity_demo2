using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimeIEnumerator
{
    public delegate void TimerCallback(float t);

    public static IEnumerator StartIEnumerator(float duration, TimerCallback callback)
    {
        // 缓存时间
        float currentTime = 0.0f;

        // 插值
        while (currentTime <= duration)
        {
            // 计算插值
            float t = currentTime / duration;
            if (t >= 0.99)
            {
                t = 1;
                callback.Invoke(t);
            }
            else
            {
                callback.Invoke(t);
            }
        
            // 增加时间
            currentTime += Time.deltaTime;
            // 等待下一帧
            yield return Time.deltaTime;
        }

    }
}
