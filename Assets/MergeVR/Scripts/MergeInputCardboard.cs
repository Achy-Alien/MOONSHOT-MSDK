using UnityEngine;
using System.Collections;

using Merge;

namespace Merge
{

	public class MergeInputCardboard : MonoBehaviour {

		private static float displayPPI = 227f; // device pixel density temp value - grab actual value in start

		private static float displayPPIX = 227f; // device pixel density temp value - grab actual value in start
		private static float displayPPIY = 227f; // device pixel density temp value - grab actual value in start


		// Use this for initialization
		void Start () {

			#if (UNITY_ANDROID && !UNITY_EDITOR)

			Merge.DisplayMetricsAndroid.DisplayMetricsAndroidSet();

			#endif

			displayPPIX = GetDevicePixelDensityX(); // store the PPI for calculations
			displayPPIY = GetDevicePixelDensityY(); // store the PPI for calculations

			displayPPI = GetDevicePixelDensity();



		}

		// Update is called once per frame
		void Update () {

		}




		public static bool GetDoubleInputUp() {

			bool bReturn = false;



			float width = (float) Screen.width / 2.0f;


			bool bReturnLeft = false;
			bool bReturnRight = false;

			for (var i = 0; i < Input.touchCount; ++i) {

				if (Input.GetTouch(i).phase == TouchPhase.Ended) {
					Touch currentTouch = Input.GetTouch(i);

					Vector2 position = currentTouch.position;



					if (position.x>width) {
						bReturnRight=true;

					}

					if (position.x<width) {
						bReturnLeft=true;

					}

				}
			}

			if (bReturnLeft && bReturnRight)
				bReturn=true;



			return bReturn;
		}

		public static bool GetDoubleInputDown() {

			bool bReturn = false;



			if (GetInputDown(0) && GetInputDown (1))
				bReturn=true;



			return bReturn;

		}


		public static bool GetDoubleInput() {

			bool bReturn = false; //default



			if (GetInput(0) && GetInput (1))
				bReturn=true;



			return bReturn;
		}


		public static bool GetSingleInput() {

			bool bReturn = false; //default

			if (GetInput(0) || GetInput (1))
				bReturn = true;


			return bReturn;
		}

		public static bool GetSingleInputDown() {

			bool bReturn = false; //default

			if (GetInputDown(0) || GetInputDown(1))
				bReturn = true;


			return bReturn;
		}

		public static bool GetSingleInputUp() {

			bool bReturn = false; //default

			if (GetInputUp(0) || GetInputUp(1))
				bReturn = true;


			return bReturn;
		}




		/*
	 * 
	 * GetInput
	 * 
	 * 
	 * 
		Returns whether the given capactive button is held down.
			
			button values are 0 for left button, 1 for right button, 2 for the middle button.

	*/



		public static bool GetInput(int button) {

			bool bReturn = false; //default;


			//if not mobile, check mouse and keyboard
			#if UNITY_EDITOR

			bReturn=Input.GetMouseButton(button);

			if (!bReturn) {

				//if controller is connected and return is not true, check circle
				if (button==0 && (Input.GetKey (KeyCode.Space) || Input.GetButton("Fire1")))
					bReturn=true;
				else if (button==1 && (Input.GetKey (KeyCode.Escape) || Input.GetButtonDown ("Fire2") ))
					bReturn=true;


			}

			#else
			//this is iOS or Android
			//getinput returns true on began, moved, or stationary

			float buffer=0.0f;

			buffer = ConvertToPixelsX(5.0f);

			float middle = (float) Screen.width / 2.0f;

			for (var i = 0; i < Input.touchCount; ++i) {

			if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetTouch(i).phase == TouchPhase.Stationary) {
			Touch currentTouch = Input.GetTouch(i);

			Vector2 position = currentTouch.position;

			if (position.x>(middle-buffer) && button==0) { //HACK adjust for trigger
			bReturn=true;
			break;
			}

			if (position.x<(middle-buffer) && button==1) {
			bReturn=true;
			break;
			}

			}
			}

			#endif





			return bReturn;
		}

		public static bool GetInputDown(int button) {

			bool bReturn = false; //default;



			//if not mobile, check mouse and keyboard
			#if UNITY_EDITOR

			if (!bReturn) {

				bReturn=Input.GetMouseButtonDown(button);

				//if controller is connected and return is not true, check circle
				if (button==0 && (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown("Fire1")))
					bReturn=true;
				else if (button==1 && (Input.GetKeyDown (KeyCode.Escape) || Input.GetButtonDown ("Fire2") ))
					bReturn=true;


			}

			#else

			float width = (float) Screen.width / 2.0f;


			for (var i = 0; i < Input.touchCount; ++i) {

			if (Input.GetTouch(i).phase == TouchPhase.Began) {
			Touch currentTouch = Input.GetTouch(i);

			Vector2 position = currentTouch.position;

			if (position.x>width && button==0) {
			bReturn=true;
			break;
			}

			if (position.x<width && button==1) {
			bReturn=true;
			break;
			}

			}
			}


			#endif








			return bReturn;


		}

		public static bool GetInputUp(int button) {

			bool bReturn = false; //default;



			//if not mobile, check mouse and keyboa
			#if UNITY_EDITOR

			bReturn=Input.GetMouseButtonUp(button);

			if (!bReturn) {

				//if controller is connected and return is not true, check circle
				if (button==0 && (Input.GetKeyUp (KeyCode.Space) || Input.GetButtonUp("Fire1")))
					bReturn=true;
				else if (button==1 && (Input.GetKeyUp (KeyCode.Escape) || Input.GetButtonUp ("Fire2") ))
					bReturn=true;


			}
			#else

			float width = (float) Screen.width / 2.0f;


			for (var i = 0; i < Input.touchCount; ++i) {

			if (Input.GetTouch(i).phase == TouchPhase.Ended) {
			Touch currentTouch = Input.GetTouch(i);

			Vector2 position = currentTouch.position;

			if (position.x>width && button==0) {
			bReturn=true;
			break;
			}

			if (position.x<width && button==1) {
			bReturn=true;
			break;
			}

			}
			}



			#endif






			return bReturn;

		}

		/// <summary>
		/// Utility function to convert from millemeters to pixels based on the device pixel density for X
		/// </summary>
		/// <returns>The to pixels.</returns>
		/// <param name="mm">Mm.</param>
		// TODO move to utility class
		private static float ConvertToPixelsX(float mm){
			float pixels = (mm * 0.039370f) * displayPPIX;
			return pixels;
		}

		/// <summary>
		/// Utility function to convert from millemeters to pixels based on the device pixel density for Y
		/// </summary>
		/// <returns>The to pixels.</returns>
		/// <param name="mm">Mm.</param>
		// TODO move to utility class
		private static float ConvertToPixelsY(float mm){
			float pixels = (mm * 0.039370f) * displayPPIY;
			return pixels;
		}



		/// <summary>
		/// Converts to milimeters from pixels based on the device pixel density
		/// </summary>
		/// <returns>The to milimeters.</returns>
		/// <param name="pixels">Pixels.</param>
		// TODO move to utility class
		private static float ConvertToMilimeters(float pixels)
		{
			float mm = (pixels / displayPPI) * 25.4f;
			return mm;
		}

		/// Gets the Device Pixel Density in inches for X
		/// </summary>
		/// <returns>The DP.</returns>
		private static float GetDevicePixelDensity()
		{


			#if (UNITY_ANDROID && !UNITY_EDITOR)

			return Merge.DisplayMetricsAndroid.DensityDPI;
			#else
			return Screen.dpi == 0 ? displayPPI : Screen.dpi; // TODO fallback for 0 DPI if unity can not determine it

			#endif
		}

		/// <summary>
		/// Gets the Device Pixel Density in inches for X
		/// </summary>
		/// <returns>The DP.</returns>
		private static float GetDevicePixelDensityX()
		{


			#if (UNITY_ANDROID && !UNITY_EDITOR)

			//Debug.Log ("MergeVRBridge Merge.DisplayMetricsAndroid.DensityDPI=" + Merge.DisplayMetricsAndroid.DensityDPI + " screen.dpi = " + Screen.dpi);

			return Merge.DisplayMetricsAndroid.XDPI;
			#else
			return Screen.dpi == 0 ? displayPPI : Screen.dpi; // TODO fallback for 0 DPI if unity can not determine it

			#endif
		}

		/// <summary>
		/// Gets the Device Pixel Density in inches for Y
		/// </summary>
		/// <returns>The DP.</returns>
		private static float GetDevicePixelDensityY()
		{


			#if (UNITY_ANDROID && !UNITY_EDITOR)

			//Debug.Log ("MergeVRBridge Merge.DisplayMetricsAndroid.DensityDPI=" + Merge.DisplayMetricsAndroid.DensityDPI + " screen.dpi = " + Screen.dpi);

			return Merge.DisplayMetricsAndroid.YDPI;
			#else
			return Screen.dpi == 0 ? displayPPI : Screen.dpi; // TODO fallback for 0 DPI if unity can not determine it

			#endif
		}


		private static float GetScreenWidth()
		{

			#if (UNITY_ANDROID && !UNITY_EDITOR)

			return Merge.DisplayMetricsAndroid.WidthPixels;
			#else

			return Screen.width;

			#endif
		}

		private static float GetScreenHeight()
		{

			#if (UNITY_ANDROID && !UNITY_EDITOR)

			return Merge.DisplayMetricsAndroid.HeightPixels;;
			#else

			return Screen.height;

			#endif
		}
	}

}



