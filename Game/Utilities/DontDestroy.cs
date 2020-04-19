using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //[SerializeField] GameObject dontDestroy;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}