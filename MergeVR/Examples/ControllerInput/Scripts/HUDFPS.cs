using UnityEngine;
using System.Collections;

public class HUDFPS : MonoBehaviour {

	// It calculates frames/second over each updateInterval,
	// so the display does not keep changing wildly.
	//
	// It is also fairly accurate at very low FPS counts (<10).
	// We do this not by simply counting frames per interval, but
	// by accumulating FPS for each frame. This way we end up with
	// correct overall FPS even if the interval renders something like
	// 5.5 frames.

	public  float updateInterval = 0.5F;

	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval





	private TextMesh txtMergeFPS;


	//controller throughput

	Quaternion oldRotation = Quaternion.identity;

	private float changecounter=0.0f;
	//private float fixedcounter=0.0f;

	private float controllerratio;

	// Use this for initialization
	void Start () {

		txtMergeFPS = gameObject.GetComponent<TextMesh>();

		if( !txtMergeFPS )
		{
			Debug.Log("HUDFPS needs a TextMesh component!");
			enabled = false;
			return;
		}

		timeleft = updateInterval; 


	
	}
	
	// Update is called once per frame
	void Update () {

		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;


		if (Merge.MSDK.State == Merge.MergeConnectionState.Connected) {

			Quaternion newRotation = Merge.MSDK.Orientation;


			if (newRotation!=oldRotation) {

				++changecounter;

			}

			oldRotation=newRotation;
		}

		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 )
		{
			// display two fractional digits (f2 format)
			float fps = accum/frames;
			string format = System.String.Format("{0:F0} FPS ",fps);
	

			float controllerratio = (changecounter/frames)*60.0f;

			if (Merge.MSDK.State == Merge.MergeConnectionState.Connected) {

				string formatController = System.String.Format("{0:F0}",controllerratio);

				txtMergeFPS.text = format + formatController;

			} else {
				
				txtMergeFPS.text = format;
			}
		
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
			changecounter=0;
		}

	
	}


	void FixedUpdate() {



	}
}
