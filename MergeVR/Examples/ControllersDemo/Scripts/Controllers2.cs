using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Merge;

public class Controllers2 : MonoBehaviour
{
	public GameObject leftController;
	public GameObject rightController;

	// Update is called once per frame
	void Update()
	{
		rightController.transform.rotation = GenericMotionController.Orientation;
		leftController.transform.rotation = MSDK.GetOrientation(1);
	}
}


