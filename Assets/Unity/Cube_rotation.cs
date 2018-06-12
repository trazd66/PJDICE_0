using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_rotation : MonoBehaviour{
	// Use this for initialization
		TKSwipeRecognizer swipeRecognizer = new TKSwipeRecognizer();
		public float rotationFactor = 2f;		
	void Start () {
		// var swipeRecognizer = new TKSwipeRecognizer();
		swipeRecognizer.gestureRecognizedEvent += ( r ) =>
		{
			Debug.Log( "swipe recognizer fired: " + r );
		};
		TouchKit.addGestureRecognizer( swipeRecognizer );
	}
	
	/* Update is called once per frame
	 * a good guide on rotations
	 * https://gamedev.stackexchange.com/questions/136174/im-rotating-an-object-on-two-axes-so-why-does-it-keep-twisting-around-the-thir
	 */
	void Update () {
			//detected a swipe
		if(swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Left){
			Quaternion targetRotation = Quaternion.AngleAxis(90f,Vector3.up) * this.transform.rotation; // the order of these multiplications matter
			StartCoroutine(rotateOverTime(this.transform.rotation,targetRotation,rotationFactor));
			swipeRecognizer.resetSwipeDirection();
		} else if(swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Right){
			Quaternion targetRotation = Quaternion.AngleAxis(90f,Vector3.down) * this.transform.rotation;
			StartCoroutine(rotateOverTime(this.transform.rotation,targetRotation,rotationFactor));
			swipeRecognizer.resetSwipeDirection();
		} else if(swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Up){
			Quaternion targetRotation = Quaternion.AngleAxis(90f,Vector3.right) * this.transform.rotation;
			StartCoroutine(rotateOverTime(this.transform.rotation,targetRotation,rotationFactor));
			swipeRecognizer.resetSwipeDirection();	
		} else if(swipeRecognizer.completedSwipeDirection == TKSwipeDirection.Down){
			Quaternion targetRotation = Quaternion.AngleAxis(90f,Vector3.left) * this.transform.rotation;
			StartCoroutine(rotateOverTime(this.transform.rotation,targetRotation,rotationFactor));
			swipeRecognizer.resetSwipeDirection();	
		}
	}

	/*
		The (S)lerp function family needs to be called each frame in order to get a smooth animation going
		the yield keyword and coroutine will continue to call slerp on a different thread essentially.
		a good guide on (s)lerp
		https://forum.unity.com/threads/smooth-slerp-rotation.458468/
	 */
	IEnumerator rotateOverTime(Quaternion origin,Quaternion target,float timeDuration){
		if (timeDuration > 0f){
			float startTime = Time.time;
			float endTime = startTime + timeDuration;
			yield return null;
			while(Time.time < endTime){
				float progress = (Time.time - startTime)/timeDuration;
				this.transform.rotation = Quaternion.Slerp(origin,target,progress);
				yield return null;
			}
		}
		this.transform.rotation = target;
	}
}
