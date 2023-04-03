using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReverseTime : MonoBehaviour
{
    public bool isReversing;
    List<ObjectTracker> trackers;
    private float ang;

    private LineRenderer lineRenderer;
    public Material lineMaterial;

    public CharacterController cc;
    public PlayerLook look;

    // Start is called before the first frame update
    void Start()
    {
        trackers = new List<ObjectTracker>();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("PlayerReverse"))
        {
            isReversing = true;
        }

        if (Input.GetButtonUp("PlayerReverse"))
        {
            isReversing = false;
        }
    }

    void FixedUpdate()
    {
        if (isReversing)
        {
            Reverse();
        }
        else
        {
            Record();
        }
    }

    public void StartReverse()
    {
        isReversing = true;
        if (look && cc)
        {
            look.enabled = false;
            cc.enabled = false;
        }
    }

    public void StopReverse()
    {
        isReversing = false;
        if (look && cc)
        {
            look.enabled = true;
            cc.enabled = true;
        }
    }

    void Record()
    {
        ang = 0;
        trackers.Insert(0, new ObjectTracker(transform.position, transform.rotation, ang));

        lineRenderer.positionCount = trackers.Count;

        for (int i = 0; i < trackers.Count; i++)
        {
            lineRenderer.SetPosition(i, trackers[i].pos);
        }

        if (trackers.Count >= 200)
        {
            trackers.RemoveAt(trackers.Count - 1);
        }
    }
    void Reverse()
    {
        if (trackers.Count > 0)
        {
            ObjectTracker tracker = trackers[0];
            transform.position = tracker.pos;
            transform.rotation = tracker.rot;

            trackers.RemoveAt(0);
            lineRenderer.positionCount = trackers.Count;
            lineRenderer.SetPositions(trackers.ConvertAll(p => p.pos).ToArray());
        }
        else
        {
            StopReverse();
        }
    }
}
