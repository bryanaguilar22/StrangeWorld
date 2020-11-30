using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator anim;
    private SpriteRenderer sr;

	void Awake () {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
	}

    public void ZombieWalk(bool walk, bool flipSide){
        anim.SetBool("Walk", walk);
        sr.flipX = flipSide;
    }

    public void ZombieStop() {
        anim.SetBool("Walk", false);
    }



} // class



































