using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManipulator : MonoBehaviour
{
    public float bulletTimeFactor = 0.05f;

    public float fastTimeFactor = 2.0f;

    void Update()
    {
        // Bullet Time
        if (Input.GetButtonDown("BulletTime"))
        {
            BulletTime();
        }

        if (Input.GetButtonUp("BulletTime"))
        {
            EndBulletTime();
        }

        // Fast Time
        if (Input.GetButtonDown("FastTime"))
        {
            FastTime();
        }

        if (Input.GetButtonUp("FastTime"))
        {
            EndFastTime();
        }
    }

    void BulletTime()
    {
        Time.timeScale = bulletTimeFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    void EndBulletTime()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }

    void FastTime()
    {
        Time.timeScale = fastTimeFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    void EndFastTime()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
}
