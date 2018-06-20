using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_rotation : MonoBehaviour{
	// Use this for initialization
	TKSwipeRecognizer swipeRecognizer = new TKSwipeRecognizer();
	private float speed = 0;  // degrees per second

	// used to scale the swipe speed to a suitable rotation speed
	private const float speedScale = 3f;

	// used to slow the rotation down
	private const float friction = 1;

	void Start () {
		// var swipeRecognizer = new TKSwipeRecognizer();
		swipeRecognizer.gestureRecognizedEvent += ( r ) =>
		{
			Debug.Log( "swipe recognizer fired: " + r );
			updateDirection();
		};
		TouchKit.addGestureRecognizer( swipeRecognizer );
	}

	// called once per frame
	/*
	Called once per frame
	Here is a good guide on rotations,
	https://gamedev.stackexchange.com/questions/136174/im-rotating-an-object-on-two-axes-so-why-does-it-keep-twisting-around-the-thir
	*/
	void Update () {
		if (speed <= 0){
			speed = 0;
		}
		else{
			speed -= friction;
		}
	}

	// this occurs when a swipe is recognized
	void updateDirection(){
		Quaternion targetRotation = Quaternion.identity;

		if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Left){
			targetRotation = (Quaternion.AngleAxis(90f, Vector3.up) * 2) * this.transform.rotation;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Right){
			targetRotation = Quaternion.AngleAxis(90f, Vector3.down) * this.transform.rotation;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Up){
			targetRotation = Quaternion.AngleAxis(90f, Vector3.right) * this.transform.rotation;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Down){
			targetRotation = Quaternion.AngleAxis(90f, Vector3.left) * this.transform.rotation;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.UpLeft){
			targetRotation = Quaternion.AngleAxis(90f, new Vector3(1, 1, 0)) * this.transform.rotation;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.UpRight){
			targetRotation = Quaternion.AngleAxis(90f, new Vector3(1, -1, 0)) * this.transform.rotation;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.DownLeft){
			targetRotation = Quaternion.AngleAxis(90f, new Vector3(-1, 1, 0)) * this.transform.rotation;
		}
		else if (swipeRecognizer.completedSwipeDirection == TKSwipeDirection.DownRight){
			targetRotation = Quaternion.AngleAxis(90f, new Vector3(-1, -1, 0)) * this.transform.rotation;
		}

		Debug.Log("swipe speed:  " + swipeRecognizer.swipeVelocity);
		Debug.Log(swipeRecognizer.completedSwipeDirection);
		speed = swipeRecognizer.swipeVelocity * speedScale;

		var degrees = Quaternion.Angle(this.transform.rotation, targetRotation);

		StartCoroutine(rotateOverTime(this.transform.rotation, targetRotation, 0.25f));

		swipeRecognizer.resetSwipeDirection();

	}

	/*
		The (S)lerp function family needs to be called each frame in order to get a smooth animation going
		the yield keyword and coroutine will continue to call slerp on a different thread essentially.
		a good guide on (s)lerp
		https://forum.unity.com/threads/smooth-slerp-rotation.458468/
	 */
	IEnumerator rotateOverTime(Quaternion origin, Quaternion target, float timeDuration){
		if (timeDuration > 0f){
			float startTime = Time.time;
			float endTime = startTime + timeDuration;

			this.transform.rotation = origin;

			yield return null;

			while(Time.time < endTime){
				float progress = (Time.time - startTime) / timeDuration;
				this.transform.rotation = Quaternion.Slerp(origin, target, progress);
				yield return null;
			}
		}

		this.transform.rotation = target;
	}
}
