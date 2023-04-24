using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolController : MonoBehaviour
{
    private ITool currentTool;
    public int currentToolIndex;
    public GameObject[] tools;
    public TextMeshProUGUI ui;
    private CameraEffectController eff;

    private void Start()
    {
        SetTool(0);
        UpdateToolUI(ui);

        eff = GetComponent<CameraEffectController>();
    }
    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0f)
        {
            // Scroll up to switch to the next weapon
            SetTool(1);
            UpdateToolUI(ui);
        }
        else if (scrollInput < 0f)
        {
            // Scroll down to switch to the previous weapon
            SetTool(-1);
            UpdateToolUI(ui);
        }


        if (Input.GetButtonDown("UseTool"))
        {
            UseTool();
            eff.StartEffect(0);
        }

        if (Input.GetButtonUp("UseTool"))
        {
            EndUseTool();
            eff.EndEffect(0);
        }
    }

    public void SetTool(int direction)
    {
        currentToolIndex = (currentToolIndex + direction + tools.Length) % tools.Length;
        currentTool = tools[currentToolIndex].GetComponent<ITool>();
    }

    public void UseTool()
    {
        currentTool.Use();
    }
    public void EndUseTool()
    {
        currentTool.EndUse();
    }

    public void UpdateToolUI(TextMeshProUGUI text)
    {
        currentTool.UpdateUI(text);
    }
}

