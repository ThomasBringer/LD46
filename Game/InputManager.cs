using System;
using System.Collections;
using UnityEngine;

public static class InputManager
{
//    #region Types

//    public enum IType { Default, Down, Up }
//    public enum PosType { Screen, World }

//    #endregion

//    #region Fingers

//    #region Finger On Screen

//    public static bool Finger(IType type = 0)
//    {
//        switch (type)
//        {
//            case IType.Down:
//#if !UNITY_EDITOR
//            return Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began;
//#else
//                return Input.GetMouseButtonDown(0);
//#endif
//            case IType.Up:
//#if !UNITY_EDITOR
//            return Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended;
//#else
//                return Input.GetMouseButtonUp(0);
//#endif
//            default:
//#if !UNITY_EDITOR
//            return Input.touchCount > 0;
//#else
//                return Input.GetMouseButton(0);
//        }
//#endif
//    }

//    //    public static bool Finger
//    //    {
//    //        get
//    //        {
//    //#if !UNITY_EDITOR
//    //            return Input.touchCount > 0;
//    //#else
//    //            return Input.GetMouseButton(0);
//    //#endif
//    //        }
//    //    }

//    //    public static bool FingerDown
//    //    {
//    //        get
//    //        {
//    //#if !UNITY_EDITOR
//    //            return Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began;
//    //#else
//    //            return Input.GetMouseButtonDown(0);
//    //#endif
//    //        }
//    //    }

//    //    public static bool FingerUp
//    //    {
//    //        get
//    //        {
//    //#if !UNITY_EDITOR
//    //            return Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended;
//    //#else
//    //            return Input.GetMouseButtonUp(0);
//    //#endif
//    //        }
//    //    }

//    #endregion

//    #region Wait For Finger

//    public static IEnumerator WaitForFinger(IType type = 0)
//    {
//        yield return new WaitUntil(() => Finger(type));
//        //yield return GameManager.gm.StartCoroutine(WaitFor(Finger));
//    }

//    public static IEnumerator RepeatRoutine(Action action)
//    {
//        for (; ; )
//        {
//            action();
//            yield return null;
//        }
//        //yield return GameManager.gm.StartCoroutine(WaitFor(Finger));
//    }

//    public static IEnumerator WhileFingerRoutine(Action action, bool finger = true, IType type = 0)
//    {
//        while (Finger(type) == finger)
//        {
//            action();
//            yield return null;
//        }
//        //yield return GameManager.gm.StartCoroutine(WaitFor(Finger));
//    }

//    public static void WhileFinger(Action action, bool finger = true, IType type = 0)
//    {
//        while (Finger(type) == finger)
//            action();
//        //yield return GameManager.gm.StartCoroutine(WaitFor(Finger));
//    }

//    //public static IEnumerator WaitForFingerDown()
//    //{
//    //    yield return new WaitUntil(() => FingerDown);
//    //    //yield return GameManager.gm.StartCoroutine(WaitFor(FingerDown));
//    //}

//    //public static IEnumerator WaitForFingerUp()
//    //{
//    //    yield return new WaitUntil(() => FingerUp);
//    //    //yield return GameManager.gm.StartCoroutine(WaitFor(FingerUp));
//    //}

//    //public static IEnumerator ChangeStateAfterFinger(GameManager.State state, IType type = 0)
//    //{
//    //    yield return WaitForFinger(type);
//    //    GameManager.GameState = state;
//    //}

//    //static IEnumerator WaitFor(bool finger)
//    //{
//    //    while (!finger) { yield return null; }
//    //}

//    #endregion

//    #region Finger Position

//    public static Vector2 FingerPos(PosType type = 0)
//    {
//        Vector2 pos;


//#if !UNITY_EDITOR
//        pos = Input.GetTouch(0).position;
//#else
//        pos = Input.mousePosition;
//#endif

//        return pos.ToWorld(type);
//    }

//    public static Vector2 FingerDeltaPos(PosType type = 0)
//    {
//        Vector2 pos;

//#if !UNITY_EDITOR
//        pos = Input.GetTouch(0).deltaPosition;
//#else
//        pos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
//#endif

//        return pos.ToWorld(type);
//    }

//    struct PosTime { public static Vector2 pos; public static float time; }

//    //static PosTime fingerPosTime;
//    //static PosTime FingerPosTime
//    //{
//    //    get { return fingerPosTime; }
//    //    set { fingerPosTime.pos = FingerPos(); fingerPosTime.time = Time.time; }
//    //}

//    public static void SaveFingerPosTime(PosType type = 0)
//    {
//        PosTime.pos = FingerPos(type); PosTime.time = Time.time;
//    }

//    public static Vector2 FingerSpeed(PosType type = 0) //get average speed of finger by second since last SaveFingerPosTime()
//    {
//        return (FingerPos(type) - PosTime.pos) / (Time.time - PosTime.time);
//    }

//    //public static float FingerSpeed(PosType type = 0) //get average speed of finger by second since last SaveFingerPosTime()
//    //{
//    //    return (FingerPos(type) - PosTime.pos).magnitude / Time.time - PosTime.time;
//    //    //fingerPosTime.pos = FingerPos(type); fingerPosTime.time = Time.time;
//    //}

//    public static Vector2 FingerDeltaPosTime(bool get, PosType type = 0)
//    {
//        Vector2 pos;

//#if !UNITY_EDITOR
//        pos = Input.GetTouch(0).deltaPosition;
//#else
//        pos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
//#endif

//        return pos.ToWorld(type);
//    }

//    static Vector2 ToWorld(this Vector2 pos, PosType type = 0)
//    {
//        return type == 0 ? pos : pos.ToWorld();
//    }

//    static Vector2 ToWorld(this Vector2 pos)
//    {
//        return Cam.recorder.ScreenToWorldPoint(pos);
//    }

//    #endregion

//    #region Finger Ray

//    public static Ray FingerRay
//    {
//        get
//        {
//            return Cam.recorder.ScreenPointToRay(FingerPos());
//        }
//    }      

//    public static bool FingerRaycast(out RaycastHit hit, LayerMask mask)
//    {
//        return Physics.Raycast(FingerRay, out hit, Mathf.Infinity, mask);
//    }

//    public static bool FingerRaycast(this Plane plane, out float enter)
//    {
//        return plane.Raycast(FingerRay, out enter);
//    }

//    #endregion

//    #endregion
}