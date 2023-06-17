using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform target;
    public float smooth_speed = 0.123f;
    public Vector3 offset = new Vector3(0.2f, 0.0f, -10.0f);
    public float damping_time = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void move_camera(bool smooth)
    {
        Vector3 destination = new Vector3(target.position.x - offset.x, offset.y, offset.z);
        if (smooth)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, damping_time);
        }
        else
        {
            this.transform.position = destination;
        }
    }

    private void LateUpdate()
    {
        move_camera(true);
    }

    //private void LateUpdate()
    //{
    //    Vector3 desired_position = new Vector3 (target.position.x, target.position.y, 0.0f) + new Vector3 (offset.x, offset.y, 0.0f);
    //    Vector3 smooth_position = Vector3.SmoothDamp(transform.position, desired_position, ref velocity, smooth_speed);
    //    transform.position = smooth_position;
    //}

}
