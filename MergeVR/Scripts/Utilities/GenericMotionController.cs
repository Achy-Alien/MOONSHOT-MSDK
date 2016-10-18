using UnityEngine;
using System.Collections;

using Merge;

/// <summary>
/// This is a utility class which serves as a Facade to all motion controller input. Instead of calling for input from one specific class,
/// use this class instead to support different motion controllers all in one place.
/// </summary>
public class GenericMotionController : MonoBehaviour
{
	private static GenericMotionController instance;

	public static MotionControllerConnectionState State
	{
		get
		{
			if (GvrController.State != GvrConnectionState.Disconnected)
			{
				return (MotionControllerConnectionState)(int)GvrController.State;
			}
			else
			{
				return (MotionControllerConnectionState)(int)MSDK.State;
			}
		}
	}

	public static Quaternion Orientation
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.Orientation;
			}
			else
			{
				return MSDK.Orientation;
			}
		}
	}
	public static Vector3 Gyro
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.Gyro;
			}
			else
			{
				return MSDK.Gyro;
			}
		}
	}
	public static Vector3 Accel
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.Accel;
			}
			else
			{
				return MSDK.Accel;
			}
		}
	}
	// TODO: Implement IsTouching
	public static bool IsTouching
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.IsTouching;
			}
			else
			{
				return MSDK.IsTouching;
			}
		}
	}
	// TODO: Implement TouchDown
	public static bool TouchDown
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.TouchDown;
			}
			else
			{
				return MSDK.TouchDown;
			}
		}
	}
	// TODO: Implement TouchUp
	public static bool TouchUp
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.TouchUp;
			}
			else
			{
				return MSDK.TouchUp;
			}
		}
	}
	// TODO: Implment TouchPos
	public static Vector2 TouchPos
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.TouchPos;
			}
			else
			{
				return MSDK.TouchPos;
			}
		}
	}
	// TODO: Implement Recentering
	public static bool Recentering
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.Recentering;
			}
			else
			{
				return MSDK.Recentering;
			}
		}
	}
	// TODO: Implement Recentered
	public static bool Recentered
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.Recentered;
			}
			else
			{
				return MSDK.Recentered;
			}
		}
	}
	// TODO: Implement ClickButton
	public static bool ClickButton
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.ClickButton;
			}
			else
			{
				return MSDK.ClickButton;
			}
		}
	}
	// TODO: Implement ClickButtonDown
	public static bool ClickButtonDown
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.ClickButtonDown;
			}
			else
			{
				return MSDK.ClickButtonDown;
			}
		}
	}
	// TODO: ClickButtonUp
	public static bool ClickButtonUp 
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.ClickButtonUp;
			}
			else
			{
				return MSDK.ClickButtonUp;
			}
		}
	}
	public static bool AppButton
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.AppButton;
			}
			else
			{
				return MSDK.AppButton;
			}
		}
	}
	public static bool AppButtonDown
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.AppButtonDown;
			}
			else
			{
				return MSDK.AppButtonDown;
			}
		}
	}
	public static bool AppButtonUp
	{
		get
		{
			if (GvrController.State == GvrConnectionState.Connected)
			{
				return GvrController.AppButtonUp;
			}
			else
			{
				return MSDK.AppButtonUp;
			}
		}
	}

	void Awake()
	{
		if (instance != null)
		{
			this.enabled = false;
			return;
		}
		instance = this;
	}

	void OnDestroy()
	{
		instance = null;
	}
}

public enum MotionControllerConnectionState
{
	/// Indicates that the controller is disconnected.
	Disconnected,
	/// Indicates that the device is scanning for controllers.
	Scanning,
	/// Indicates that the device is connecting to a controller.
	Connecting,
	/// Indicates that the device is connected to a controller.
	Connected,
	/// Indicates that an error has occurred.
	Error,
};

