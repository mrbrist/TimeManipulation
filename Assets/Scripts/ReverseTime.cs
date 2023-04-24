using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTime : MonoBehaviour
{
    public bool isReversing;
    List<ObjectTracker> trackers;
    private Rigidbody rb;
    public bool isMovingObject;
    private CirlceMovement cm;
    private float ang;

    private LineRenderer lineRenderer;
    public Material lineMaterial;

    public CharacterController cc;
    public PlayerLook look;

    // Start is called before the first frame update
    void Start()
    {
        trackers = new List<ObjectTracker>();
        rb = GetComponent<Rigidbody>();

        if (isMovingObject)
        {
            cm = GetComponent<CirlceMovement>();
        }

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
    }

    void FixedUpdate()
    {
        if (isReversing)
        {
            Reverse();
        }
        else if (transform.hasChanged)
        {
            Record();
        }

        transform.hasChanged = false;
    }

    public void StartReverse()
    {
        isReversing = true;
        if(rb)
        {
            rb.isKinematic = true;
        }
        if (cm)
        {
            cm.isActive = false;
        }
        if(look && cc)
        {
            look.enabled = false;
            cc.enabled = false;
        }
    }

    public void StopReverse()
    {
        isReversing = false;
        if (rb)
        {
            rb.isKinematic = false;
        }
        if (cm)
        {
            cm.isActive = true;
        }
        if (look && cc)
        {
            look.enabled = true;
            cc.enabled = true;
        }
    }

    void Record()
    {
        if (cm)
        {
            ang = cm.angle;
        }
        else
        {
            ang = 0;
        }
        trackers.Insert(0, new ObjectTracker(transform.position, transform.rotation, ang));

        lineRenderer.positionCount = trackers.Count;

        for (int i = 0; i < trackers.Count; i++)
        {
            lineRenderer.SetPosition(i, trackers[i].pos);
        }

        if (trackers.Count >= 200)
        {
            trackers.RemoveAt(trackers.Count-1);
        }
    }
    void Reverse()
    {
        if (trackers.Count > 0)
        {
            ObjectTracker tracker = trackers[0];
            transform.position = tracker.pos;
            transform.rotation = tracker.rot;

            if (cm)
            {
                cm.angle = tracker.ang;
            }

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
