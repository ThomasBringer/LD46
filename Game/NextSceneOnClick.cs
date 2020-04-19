using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneOnClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Useful.LoadNextScene();
        }
    }        
}