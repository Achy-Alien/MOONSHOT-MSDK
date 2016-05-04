using UnityEngine;
using System.Collections;
using Merge;

public class MergeDemo : MonoBehaviour {

	public GameObject cubeRight, cubeLeft, cubeTop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {




		if (Merge.MergeInputCardboard.GetDoubleInput()) {

			cubeTop.GetComponent<Renderer>().material.color=Color.red;
			cubeLeft.GetComponent<Renderer>().material.color=Color.white;
			cubeRight.GetComponent<Renderer>().material.color=Color.white;

		} else {

			cubeTop.GetComponent<Renderer>().material.color=Color.white;

			if (Merge.MergeInputCardboard.GetInput(1)) {
				cubeLeft.GetComponent<Renderer>().material.color=Color.red;
			} else {
				cubeLeft.GetComponent<Renderer>().material.color=Color.white;
			}


			if (Merge.MergeInputCardboard.GetInput(0)) {
				cubeRight.GetComponent<Renderer>().material.color=Color.red;
			} else {
				cubeRight.GetComponent<Renderer>().material.color=Color.white;
			}

		}
	
	}
}
