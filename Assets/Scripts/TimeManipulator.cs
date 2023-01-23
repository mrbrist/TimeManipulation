using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManipulator : MonoBehaviour
{
    public float timeFactor = 0.05f;
    public float bulletTimeLength = 4f;

    void Update()
    {
        if (Input.GetButtonDown("BulletTime"))
        {
            BulletTime();
        }

        if (Input.GetButtonUp("BulletTime"))
        {
            EndBulletTime();
        }
    }

    void BulletTime()
    {
        Time.timeScale = timeFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    void EndBulletTime()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
}
