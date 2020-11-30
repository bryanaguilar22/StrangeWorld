using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    private PlayerWalk playerWalk;
	
	void Start () {
        playerWalk = GetComponent<PlayerWalk>();
	}
	
	void Update () {

        //if(Input.touchCount > 0) {

        //    Touch t = Input.GetTouch(0);

        //    if(t.phase == TouchPhase.Began) {
        //        print("Touch BEGAN");
        //    }

        //    if (t.phase == TouchPhase.Ended)
        //    {
        //        print("Touch ENDED");
        //    }

        //    if (t.phase == TouchPhase.Moved)
        //    {
        //        print("Touch MOVING");
        //    }

        //}

        //for (int i = 0; i < Input.touchCount; i++) {
            
        //    print("The position of the touch is " + Input.touches[i].position);

        //}
		
        //if(Input.touchCount > 0) {

        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touch_Pos = Camera.main.ScreenToWorldPoint(touch.position);

        //    if (touch_Pos.x > 0) {

        //        playerWalk.MoveRight();

        //    } else if (touch_Pos.x < 0) {

        //        playerWalk.MoveLeft();

        //    }

        //} else {
        //    playerWalk.StopMoving();
        //}

	}


} // class






























