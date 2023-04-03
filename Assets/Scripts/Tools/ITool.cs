using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface ITool
{
    void Use();
    void EndUse();
    void UpdateUI(TextMeshProUGUI text);
}