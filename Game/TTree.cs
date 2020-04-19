using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTree : MonoBehaviour
{
    Renderer[] rdrrs;
    Animator anim;

    [SerializeField] Material mat;
    [SerializeField] Material emissionMat;

    static TTree[] trees;

    [SerializeField] WalkPoint sideWP;
    [SerializeField] WalkPoint topWP;
    [SerializeField] WalkPoint wPAtPos;

    void Awake()
    {
        rdrrs = GetComponentsInChildren<Renderer>();
        anim = GetComponent<Animator>();
        trees = FindObjectsOfType<TTree>();

        sideWP.gameObject.SetActive(false);// sideWP.SetWork(false);//sideWP.Work = false;
        wPAtPos.gameObject.SetActive(false);//wPAtPos.SetWork(false);//wPAtPos.Work = false;// .gameObject.SetActive(false);

        //if (WalkPoint.GetWPAtPos(sideWP.transform.position) != null) sideWP.gameObject.SetActive(false);

        //        print("for " + gameObject + ", wPAtPos: " + wPAtPos.transform.parent.gameObject); WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP)
    }

    //void Start()
    //{
    //    wPAtPos = WalkPoint.GetWPAtPos(transform.position).gameObject;
    //}

    //GameObject wPAtPos;

    bool selected;
    public bool Selected
    {
        set
        {
            foreach (var rdrr in rdrrs) rdrr.material = value ? emissionMat : mat;

            selected = value;
            //print("tree " + gameObject + " selected " + value);
        }
    }

    public static void TryCutAll()
    {
        foreach (var tree in trees)
            tree.TryCut();

        //for (int i = 0; i < 5; i++)
        //{
            foreach (var tree in trees)
                tree.ManageCut();
        


        WalkPoint.GeneratePaths();
    }

    void TryCut()
    {
        if (selected)
        {
            Selected = false;
            //print("found: "+WalkPoint.GetWPAtPos(transform.position).transform.parent.name);
            //WalkPoint.GetWPAtPos(transform.position).gameObject.SetActive(false);// enabled = false;
        }
        else
        {
            Cut();
            //ManageCut();
        }
    }

    void ManageCut()
    {
        if (!cut) return;

        wPAtPos.gameObject.SetActive(true); //wPAtPos.SetWork(true);// wPAtPos.Work = true; //wPAtPos.gameObject.SetActive(true);
        if (Player.player.current == topWP)
        {
            Player.player.Jump(WalkPoint.GetWPAtPos(transform.position + 2 * transform.forward), transform.forward, "Tree");
        }
        topWP.gameObject.SetActive(false); //topWP.SetWork(false); //topWP.Work = false;//            topWP.gameObject.SetActive(false);

        //print("for " + gameObject + ", sideWP.transform.position:" + sideWP.transform.position + ", WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP): " + WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP));

        sideWP.gameObject.SetActive(WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP) == null || WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP).block);//sideWP.Work = WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP) == null;//sideWP.SetWork(WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP) == null); //sideWP.Work = WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP) == null;//            sideWP.gameObject.SetActive(WalkPoint.GetWPAtPos(sideWP.transform.position, sideWP) == null);
    }

    bool cut = false;

    void Cut()
    {
        anim.SetTrigger("Fall");
        cut = true;
    }
}