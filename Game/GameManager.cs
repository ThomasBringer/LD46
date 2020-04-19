using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public LayerMask ground;
    public LayerMask trees;

    void Awake()
    {
        gm = this;
    }

    void Start()
    {
        //GState = State.Choose;
        //////Console.Print("Click on the tree you want to keep alive");
    }

    //public enum State { Choose, Play }

    //static State gState;
    //public static State GState
    //{
    //    get { return gState; }
    //    set
    //    {
    //        gState = value;
    //    }
    //}
}