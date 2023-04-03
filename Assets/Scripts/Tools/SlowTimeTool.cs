using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlowTimeTool : MonoBehaviour, ITool
{
    public Sprite spr;

    public void Use()
    {
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    public void EndUse()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    public void UpdateUI(TextMeshProUGUI text)
    {
        text.text = "Slow";
    }
}
