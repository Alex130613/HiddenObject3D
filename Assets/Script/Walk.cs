using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    public float SpeedTrans=5;
    public AudioSource walk;
    public float SpeedRot=30;
    public static float vertical, horizontal;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        walk.Play(0);
    }
    void Update () {
        horizontal = Input.GetAxis("Horizontal") * SpeedRot * Time.deltaTime;
        transform.Rotate(0,horizontal,0);
        vertical = Input.GetAxis("Vertical") * SpeedTrans * Time.deltaTime;
        animator.SetBool("Walk", (vertical>0));
        animator.SetBool("BackWalk", (vertical<0));
        transform.Translate(0, 0, vertical);
        if (vertical != 0) walk.UnPause();
        else walk.Pause();
	}
}
