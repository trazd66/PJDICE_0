using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_rotation : MonoBehaviour{
	// Use this for initialization
	TKSwipeRecognizer swipeRecognizer = new TKSwipeRecognizer();

	private float speed = 0;  // rotation speed - degrees per second

	// used to scale the swipe speed to a suitable rotation speed
	private const float speedScale = 5f;

	// used to slow the rotation down - decrease in speed per second
	private const float friction = 90f;

	// the axis the cube is being rotated on
	private Vector3 rotAxis = Vector3.zero;

	void Start () {
		swipeRecognizer.gestureRecognizedEvent += ( r ) =>
		{
			updateDirection();
		};
		TouchKit.addGestureRecognizer( swipeRecognizer );
	}

	// Occurs every frame
	void Update () {

		this.transform.rotation = Quaternion.AngleAxis(speed * Time.deltaTime, rotAxis) * this.transform.rotation;

		if (speed <= 0){
			speed = 0;
		}
		else{
			speed -= friction * Time.deltaTime;
		}
	}

	/*
	 * This occurs when a swipe is recognized
	 *
	 * Update the axis the cube is rotating on based on the swipe direction and set
	 * the rotation speed based on the swipe speed.
	*/
	void updateDirection(){
		if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Left){
			rotAxis = Vector3.up;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Right){
			rotAxis = Vector3.down;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Up){
			rotAxis = Vector3.right;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Down){
			rotAxis = Vector3.left;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.UpLeft){
			rotAxis = new Vector3(1, 1, 0);
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.UpRight){
			rotAxis = new Vector3(1, -1, 0);
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.DownLeft){
			rotAxis = new Vector3(-1, 1, 0);
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.DownRight){
			rotAxis = new Vector3(-1, -1, 0);
		}

		speed = swipeRecognizer.swipeVelocity * speedScale;

		swipeRecognizer.resetSwipeDirection();

	}

}
