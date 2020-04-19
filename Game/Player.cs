using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public static bool prevent = false;

    public static Player player;

    [SerializeField] WalkPoint origin;
    public WalkPoint current;
    WalkPoint Current
    {
        set
        {
            transform.position = value.transform.position;
            current = value;
            moving = false;
            if (value.block) transform.SetParent(value.transform);
            if (value.end) Useful.LoadNextScene();
        }
    }
    WalkPoint next;

    //Vector3 MoveInput { get { return Cam.camPivot.right * Input.GetAxisRaw("Horizontal") + Cam.camPivot.forward * Input.GetAxisRaw("Vertical"); } }

    Transform child;
    Animator anim;

    public static bool moving = false;

    void Awake()
    {
        player = this;
        anim = GetComponent<Animator>();
        child = transform.GetChild(0);

        //print("origin.work " + origin.work);
    }

    void Start()
    {
        Current = origin;
    }

    void Update()
    {
        //switch (GameManager.GState)
        //{
        //    case GameManager.State.Choose: Choose(); return;
        //    case GameManager.State.Play: Play(); return;
        //}
        Choose();
        Play();
    }

    TTree selected;
    bool chosen = false;

    void Choose()
    {
        if (chosen) return;

        if (selected != null) selected.Selected = false;

        RaycastHit hit;
        if (Physics.Raycast(Cam.recorder.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, GameManager.gm.trees))
        {
            //if (selected != null) selected.Selected = false;
            TTree tree = hit.collider.GetComponent<TTree>();
            selected = tree;
            tree.Selected = true;
            if (Input.GetMouseButtonDown(0))
            {
                TTree.TryCutAll();
                //GameManager.GState = GameManager.State.Play;
                //////Console.Print("Use the arrow keys to move");
                //////Console.Print("Use R to restart", 15);

                chosen = true;
            }
        }

        //if(Physics.Raycast(Cam.recorder.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask);)

        //if (InputManager.Finger(InputManager.IType.Down))
        //{

        //    RaycastHit hit;
        //    if (InputManager.FingerRaycast(out hit, GameManager.gm.ground))
        //    {

        //    }
        //}
    }

    void Play()
    {
        if (prevent) return;

        if (!moving)
        {
            TryMove(KeyCode.UpArrow, new Vector3Int(0, 0, 1));
            TryMove(KeyCode.DownArrow, new Vector3Int(0, 0, -1));
            TryMove(KeyCode.RightArrow, Vector3Int.right);
            TryMove(KeyCode.LeftArrow, Vector3Int.left);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Useful.ReloadScene();
        }
    }

    void TryMove(KeyCode key, Vector3Int dir)
    {
        if (Input.GetKeyDown(key))
        {
            //////Console.UnPrint("Use the arrow keys to move");

            WalkPoint wP;
            //print("current.work " + current.work);
            if (current.connectedWPs.TryGetValue(Dir(dir), out wP))
            {
                /*if (wP.GetWork())*/


                //dir.y > 0 ? "Up" : dir.y < 0 ? "Down" : ""

                Jump(wP, Dir(dir), "Jump" + ((wP.transform.position.y - transform.position.y).Approximate(0)?"": ((wP.transform.position.y - transform.position.y) > 0 ? "Up" : "Down")));//if (wP.Work) Jump(wP, Dir(dir));

                if (current.block && !wP.block) transform.SetParent(null);
                //next = wP;
                //print(dir);


            }
            //else {

            //    print("failure " + Dir(dir)); }
            //    foreach (var item in current.connectedWPs)
            //    {
            //        print("key: " + item.Key + ", value: " + item.Value);
            //    }

        }
    }

    public void Jump(WalkPoint thisWP, Vector3 thisDir, string trigger = "Jump")
    {
        next = thisWP;
        child.forward = thisDir;
        anim.SetTrigger(trigger);
        moving = true;
    }

    public void EndMove()
    {
        Current = next;
    }

    Vector3Int Dir(Vector3Int dir) { return Cam.cam.rotPivot.right.RoundToInt() * dir.x + Cam.cam.rotPivot.forward.RoundToInt() * dir.z; }
}
//void Update()
//{
//    //if (InputManager.Finger(InputManager.IType.Down))
//    //{

//    //    RaycastHit hit;
//    //    if (InputManager.FingerRaycast(out hit, GameManager.gm.ground))
//    //    {

//    //    }
//    //}
//}

//void FindPath(WalkPoint origin, WalkPoint end)
//{
//    var possiblePaths = new List<List<WalkPoint>>();


//}

//void TryPath(WalkPoint origin, WalkPoint end)
//{
//    var visited = new List<WalkPoint>();

//    visited.Add(origin);

//    for (; ; )
//    {
//        foreach (var newWPs in visited.Last().connectedWPs)
//        {
//            if()
//        }
//    }

//    origin.connectedWPs[0]
//}