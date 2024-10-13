using UnityEngine;
using System.Collections;

/// <summary>
/// Class in charge to listen the touch or click, and send event to subscribers
/// </summary>
public class InputTouch : MonoBehaviour 
{
	/// <summary>
	/// Delegate to listen the touch down or click down, and send event to subscribers
	/// </summary>
	public delegate void OnTouchDown(TouchDirection td);
	public static event OnTouchDown OnTouchedDown;
	/// <summary>
	/// Delegate to listen the touch up or click up, and send event to subscribers
	/// </summary>
	public delegate void OnTouchUp();
	public static event OnTouchUp OnTouchedUp;

	/// <summary>
	/// Listening for inputs
	/// </summary>
	void Update()
	{
		if(!Application.isMobilePlatform)
		{

			if (Input.GetKeyDown (KeyCode.LeftArrow))
			{
				if(OnTouchedDown!=null)
					OnTouchedDown(TouchDirection.left);

				return;
			} 
			else if (Input.GetKeyDown (KeyCode.RightArrow))
			{
				if(OnTouchedDown!=null)
					OnTouchedDown(TouchDirection.right);

				return;
			}
			else if (Input.GetKeyUp (KeyCode.LeftArrow))
			{
				if(OnTouchedUp!=null)
					OnTouchedUp();

				return;
			}
			else if (Input.GetKeyUp (KeyCode.RightArrow))
			{
				if(OnTouchedUp!=null)
					OnTouchedUp();

				return;
			}

			if(Input.anyKeyDown)
			{
				if(OnTouchedDown!=null)
					OnTouchedDown(TouchDirection.none);
			}

			return;
		}

		#if UNITY_TVOS

		float h = Input.GetAxis("Horizontal");

		if(h < 0)
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.left);
		}
		else if(h > 0)
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.right);
		}

		#endif

		#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_TVOS 
		if (Application.isMobilePlatform || Application.isEditor) 
		{
			int nbTouches = Input.touchCount;

			if (nbTouches > 0) 
			{
				Touch touch = Input.GetTouch (0);

				TouchPhase phase = touch.phase;

				if (phase == TouchPhase.Began) 
				{
					if (touch.position.x < Screen.width / 2f)
					{
						if(OnTouchedDown!=null)
							OnTouchedDown(TouchDirection.left);
					}
					else
					{
						if(OnTouchedDown!=null)
							OnTouchedDown(TouchDirection.right);
					}
				}

				if (phase == TouchPhase.Ended)
				{
					if(OnTouchedUp!=null)
						OnTouchedUp();
				}
			}
		}
	

		#endif
	}
}

/// <summary>
/// 3 type of touch: left if on the left of the screen, right if on the right of the screen, or none
/// </summary>
public enum TouchDirection
{
	none,
	left,
	right
}