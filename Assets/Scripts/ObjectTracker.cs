using UnityEngine;

public class ObjectTracker
{
    public Vector3 pos;
    public Quaternion rot;

    public ObjectTracker(Vector3 _pos, Quaternion _rot)
    {
        pos = _pos;
        rot = _rot;
    }
}
