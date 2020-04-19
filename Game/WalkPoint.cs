using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPoint : MonoBehaviour
{
    //bool work = true;

    //public bool GetWork()
    //{
    //    return work;
    //}
    //public void SetWork(bool value)
    //{
    //    work = value;
    //}

    [SerializeField] float maxDistance = 1.2f;

    [HideInInspector] public Dictionary<Vector3Int, WalkPoint> connectedWPs;

    public bool block = false;
    public bool end = false;

    void Start()
    {
        //var results = new Dictionary<Vector3, WalkPoint>();
        //var results = new List<ConectedWP>();

        wPs = FindObjectsOfType<WalkPoint>();

        if (GetWPAtPos(transform.position, this)!=null) Debug.LogError("Walk Point Duplicate Here " + transform.parent.gameObject.name + ", " + transform.position);

        //GeneratePaths();

        //connectedWPs = results.ToArray();

        //var results = new List<WalkPoint>();

        //foreach (var wP in FindObjectsOfType<WalkPoint>())
        //{
        //    if (Vector3.Distance(transform.position, wP.transform.position) <= maxDistance && wP != this)
        //        results.Add(wP);
        //}


        //connectedWPs = results.ToArray();
        GeneratePaths();

        if (transform.parent.gameObject.name == "Groundg")
        {
            print("for " + transform.parent.gameObject + ", " + connectedWPs.Count + " connected walk points:");
            foreach (var i in connectedWPs)
            {
                print(i.Value.transform.parent.gameObject);
            }
        }
    }

    public static WalkPoint[] wPs;

    public static WalkPoint GetWPAtPos(Vector3 pos, WalkPoint except = null)
    {
        foreach (var wP in wPs)
        {
            if (wP.transform.position.Approximate(pos) && wP != except) return wP;
            //if (wP.transform.position == pos && wP != except) return wP;
        }
        return null;
    }

    public static void GeneratePaths()
    {
        //print("generate paths");

        foreach (var wP in wPs)
        {
            wP.GeneratePath();
        }
    }

    void GeneratePath()
    {
        //if (!work) return;

        //print("generate path");

        connectedWPs = new Dictionary<Vector3Int, WalkPoint>();

        foreach (var wP in FindObjectsOfType<WalkPoint>())
        {
            if (Vector3.Distance(transform.position, wP.transform.position) <= maxDistance && wP != this)
            {
                Vector3 dir = wP.transform.position - transform.position;
                connectedWPs.Add(Vector3Int.right * Mathf.RoundToInt(dir.x) + new Vector3Int(0, 0, 1) * Mathf.RoundToInt(dir.z), wP);

            }
        }

        //if (gameObject.name == "WPvds")
        //{
        //    print("for " + transform.parent.gameObject + ", " + connectedWPs.Count + " connected walk points:");
        //    foreach (var i in connectedWPs)
        //    {
        //        print(i.Value.transform.parent.gameObject);
        //    }
        //}
    }
}

//public class ConectedWP
//{
//    Vector3 dir;
//    WalkPoint wP;

//    void ConnectedWP(Vector3 thisDir, WalkPoint thisWP)
//    {
//        dir = thisDir; wP = thisWP;
//    }
//}