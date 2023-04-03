using UnityEngine;

public class ObjectTracker
{
    public Vector3 pos;
    public Quaternion rot;
    public float ang;

    public ObjectTracker(Vector3 _pos, Quaternion _rot, float _ang)
    {
        pos = _pos;
        rot = _rot;
        ang = _ang;
    }
}
