using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Vector3[] positions;
    [SerializeField] float time = .5f;

    int i = 0;
    int I
    {
        get { return i; }
        set { i = value % positions.Length; }
    }

    Vector3 target;
    Vector3 vel;

    void Awake()
    {
        transform.position = target = positions[0];
    }

    void TryMove()
    {
        if (Player.moving) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            I++;
            target = positions[i];
            StartCoroutine(Move(target));
        }
    }

    void Update()
    {
        TryMove();
        if (moving) transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, time);
    }

    bool moving = false;

    IEnumerator Move(Vector3 pos)
    {
        moving = Player.prevent = true;

        yield return new WaitForSeconds(time * 2);

        moving = Player.prevent = false;
        transform.position = pos;

        RemoveDoubles();

        WalkPoint.GeneratePaths();
    }

    void RemoveDoubles()
    {
        foreach (var wP in GetComponentsInChildren<WalkPoint>())
        {
            //child.GetChild(0).gameObject.SetActive(true);

            //WalkPoint wP = child.GetComponentInChildren<WalkPoint>();
            //print("wP " + wP);

            wP.gameObject.SetActive(WalkPoint.GetWPAtPos(wP.transform.position, wP) == null);
        }

        //foreach (Transform child in transform/* GetComponentsInChildren<WalkPoint>()*/)
        //{
        //    //child.GetChild(0).gameObject.SetActive(true);

        //    WalkPoint wP = child.GetComponentInChildren<WalkPoint>();
        //    //print("wP " + wP);


        //    wP.gameObject.SetActive(WalkPoint.GetWPAtPos(wP.transform.position, wP) == null);
        //}
    }
}