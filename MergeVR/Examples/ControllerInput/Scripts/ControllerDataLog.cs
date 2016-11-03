using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Merge;

public class ControllerDataLog : MonoBehaviour
{
	public Text completeDataText;

	public int nControllerIndex = 0;

	public GameObject controller;

	void Update()
	{
		if (Merge.MSDK.GetState(nControllerIndex) == MergeConnectionState.Connected)
		{
			Vector3 cachedControllerLinear = new Vector3(
				                                 Merge.MSDK.Instance.GetController(nControllerIndex).cData.LinearAcceleration.x,
				                                 Merge.MSDK.Instance.GetController(nControllerIndex).cData.LinearAcceleration.y,
				                                 Merge.MSDK.Instance.GetController(nControllerIndex).cData.LinearAcceleration.z);
			cachedControllerLinear = new Vector3(cachedControllerLinear.x / 300, cachedControllerLinear.y / 300, cachedControllerLinear.z / 300);
			
			completeDataText.text = "Controller Count : " + Merge.MSDK.Instance.ControllerCount;
			//completeDataText.text += "\n Connected: " + Merge.MSDK.Instance.GetController (nControllerIndex).cData.Connected;
			completeDataText.text += "\n UUID: " + Merge.MSDK.Instance.GetController(nControllerIndex).cData.UUID;
			//completeDataText.text += "\n Buttons: " + Merge.MSDK.Instance.GetController (nControllerIndex).cData.Buttons;
			//completeDataText.text += "\n RSSI: " + Merge.MSDK.Instance.GetController (nControllerIndex).cData.RSSI;
			completeDataText.text += "\n Firmware: " + Merge.MSDK.Instance.GetController(nControllerIndex).cData.firmwareVersion;
			//completeDataText.text += "\n Battery: " + Merge.MSDK.Instance.GetController (nControllerIndex).cData.BatteryLevel;
			completeDataText.text += "\n Calibrated: " + Merge.MSDK.Instance.GetController(nControllerIndex).cData.calibrated;
			completeDataText.text += "\n Orientation: " + Merge.MSDK.GetOrientation(nControllerIndex);
			completeDataText.text += "\n Linear: " + cachedControllerLinear.ToString();
			//completeDataText.text += "\n Circle Button: " + Merge.MSDK.Instance.GetController ().GetButton ("Circle");

			completeDataText.text += "\n Joystick " + Merge.MSDK.GetJoystickX(nControllerIndex) + ", " + Merge.MSDK.GetJoystickY(nControllerIndex);
			//completeDataText.text += "\n Joystick Y: " + Merge.MSDK.Instance.GetController (nControllerIndex).controllerJoystickY;

			completeDataText.text += "\n Circle: " + MSDK.AppButton; // Merge.MSDK.Instance.GetController(nControllerIndex).GetButton("Circle");
			completeDataText.text += "\n Up: " + Merge.MSDK.Instance.GetController(nControllerIndex).GetButton("home");
			completeDataText.text += "\n Square: " + MSDK.SquareButton; // Merge.MSDK.Instance.GetController(nControllerIndex).GetButton("Square");
			completeDataText.text += "\n Down: " + MSDK.DownButton; // Merge.MSDK.Instance.GetController(nControllerIndex).GetButton("Down");
			completeDataText.text += "\n Trigger1: " + MSDK.TriggerOneButton; // Merge.MSDK.Instance.GetController(nControllerIndex).GetButton("Trigger1");
			completeDataText.text += "\n Trigger2: " + MSDK.TriggerTwoButton; // Merge.MSDK.Instance.GetController(nControllerIndex).GetButton("Trigger2");
			completeDataText.text += "\n Z: " + MSDK.ClickButton; // Merge.MSDK.Instance.GetController (nControllerIndex).GetButton ("Z");
			completeDataText.text += "\n Home: " + Merge.MSDK.Instance.GetController (nControllerIndex).GetButton ("power");

			completeDataText.text += "\n Euler: " + Merge.MSDK.GetOrientation(nControllerIndex).eulerAngles.x + "," + Merge.MSDK.GetOrientation(nControllerIndex).eulerAngles.y + "," + Merge.MSDK.GetOrientation(nControllerIndex).eulerAngles.z;
		}
		else
		{
			completeDataText.text = "Waiting for Controller to connect...";
		}
	}
}

