using UnityEngine;
using System.Collections;

public class MergeTrackText : MonoBehaviour {
	
	public Transform mainCamera;

	public float speedTrack=1.0f;

	public bool trackOrientation=true;

	private float startDistance;

	private float initialYMessage;


	// Use this for initialization
	void Start () {
	
		startDistance= Vector3.Distance(mainCamera.position, transform.position);

		initialYMessage=transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {


		Vector3 startTarget= mainCamera.transform.forward*startDistance+mainCamera.transform.position;

		Vector3 correctedTarget = new Vector3(startTarget.x,initialYMessage,startTarget.z);

		float dist = Vector3.Distance(transform.position, correctedTarget);



		float step = dist * speedTrack * Time.deltaTime;


		transform.position = Vector3.MoveTowards(transform.position, correctedTarget, step);



		if (trackOrientation)
			transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);

	
	}
}
