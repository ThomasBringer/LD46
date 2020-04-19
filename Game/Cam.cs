using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public static Cam cam;
    public static Camera recorder;
    public Transform rotPivot;

    Animator anim;

    void Awake()
    {
        cam = this;
        recorder = GetComponent<Camera>();
        anim = GetComponentInParent<Animator>();
    }

    Quaternion next;

    bool rotating;

    void Update()
    {
        if (rotating) return;

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Right");

            rotating = true;

            next = Quaternion.Euler(Vector3.up * (rotPivot.eulerAngles.y - 90));
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Left");

            rotating = true;

            next = Quaternion.Euler(Vector3.up * (rotPivot.eulerAngles.y + 90));
        }
    }

    public void EndRotation()
    {
        rotPivot.rotation = next;

        rotating = false;
    }
}