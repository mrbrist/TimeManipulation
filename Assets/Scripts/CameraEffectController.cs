using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraEffectController : MonoBehaviour
{
    public GameObject obj;
    private UnityEngine.Rendering.Volume vol1;
    private UnityEngine.Rendering.Volume vol2;
    public bool active1 = false;
    public bool active2 = false;

    private void Start()
    {
        vol1 = obj.GetComponents<UnityEngine.Rendering.Volume>()[0];
        vol2 = obj.GetComponents<UnityEngine.Rendering.Volume>()[1];
    }
    // Start is called before the first frame update
    void Update()
    {
        if (active1 && vol1.weight <= 1)
        {
            vol1.weight += 2f * Time.deltaTime;
        } else if (vol1.weight > 0)
        {
            vol1.weight -= 1f * Time.deltaTime;
        }

        if (active2 && vol2.weight <= 1)
        {
            vol2.weight += 2f * Time.deltaTime;
        }
        else if (vol2.weight > 0)
        {
            vol2.weight -= 1f * Time.deltaTime;
        }
    }
    public void StartEffect(int index)
    {
        if (index == 0)
        {
            active1 = true;
        }
        else
        {
            active2 = true;
        }
    }
    public void EndEffect(int index)
    {
        if (index == 0)
        {
            active1 = false;
        }
        else
        {
            active2 = false;
        }
    }
}
