using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]
public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    //private Animator anim;

    public void Awake()
    {
        instance = this;
        //anim = GetComponent<Animator>();
    }
    
    //public void SetBringToCharacters(bool value)
    //{
    //    //anim.SetBool("Bring", value);
    //}
}
