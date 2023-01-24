using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTime : MonoBehaviour
{
    public bool isReversing;
    List<ObjectTracker> trackers;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        trackers = new List<ObjectTracker>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ReverseTime"))
        {
            isReversing = true;
            rb.isKinematic = true;
        }
        if (Input.GetButtonUp("ReverseTime"))
        {
            isReversing = false;
            rb.isKinematic = false;
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

    void Record()
    {
        trackers.Insert(0, new ObjectTracker(transform.position, transform.rotation));
    }
    void Reverse()
    {
        if (trackers.Count > 0)
        {
            ObjectTracker tracker = trackers[0];
            transform.position = tracker.pos;
            transform.rotation = tracker.rot;
            trackers.RemoveAt(0);
        }
        else
        {
            isReversing = false;
        }
    }
}
