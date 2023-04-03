using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeReverseTool : MonoBehaviour, ITool
{
    public Sprite spr;
    private ReverseTime[] objs;
    public void Use()
    {
        objs = FindObjectsOfType<ReverseTime>();
        foreach (var e in objs)
        {
            e.StartReverse();
        }
    }
    public void EndUse()
    {
        objs = FindObjectsOfType<ReverseTime>();
        foreach (var e in objs)
        {
            e.StopReverse();
        }
    }
    public void UpdateUI(TextMeshProUGUI text)
    {
        text.text = "Reverse";
    }
}
