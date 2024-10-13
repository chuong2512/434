using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;

/// <summary>
/// Attached to ObstaclePrefab prefab in the prefab folder. In charge to initialize the spike and anim them in, and destroy them if ot of screen.
/// </summary>
public class ObstacleLogic : MonoBehaviour 
{
	public GameObject obstacleSprite;

	SpriteRenderer sr;
	GameManager gameManager;

	public bool isVisible = false;

	float decal = -1f;

	void Awake()
	{
		this.gameManager = FindObjectOfType<GameManager>();
		obstacleSprite.SetActive(false);
		sr = obstacleSprite.GetComponent<SpriteRenderer>();
		isVisible = false;
		Color c = gameManager.hazardColor;
		c.a = 0f;
		sr.color = c;
	}

	public void Init(float rot, bool isDown)
	{
		StartCoroutine(DOStart(rot, isDown));
	}

	IEnumerator DOStart(float rot, bool isDown)
	{
		decal = obstacleSprite.GetComponent<SpriteRenderer>().sprite.bounds.size.y * obstacleSprite.transform.localScale.y/1.5f;

		float lastPosSR = -1000000f;

		bool isAnimated = false;


		while(true)
		{
			if(!isAnimated)
			{
				Color c = gameManager.hazardColor;
				c.a = 0f;
				sr.color = c;
			}

			if(lastPosSR == obstacleSprite.transform.localPosition.x && !isAnimated)
			{
				obstacleSprite.SetActive(true);

				isAnimated = true;

				Color c = gameManager.hazardColor;
				c.a = 1f;
				sr.color = c;

				int sign = +1;

				if(isDown)
					sign = -1;

				var currentPosSprite = obstacleSprite.transform.localPosition;

				obstacleSprite.transform.localPosition = new Vector3(currentPosSprite.x + sign * 0.2f, currentPosSprite.y, currentPosSprite.z);

				obstacleSprite.transform.DOLocalMoveX(currentPosSprite.x, 0.2f).OnComplete(() => {

					StopAllCoroutines();

					StartCoroutine(CheckVisibility());
				});
			}

			if(!isAnimated)
			{
				lastPosSR = obstacleSprite.transform.localPosition.x;

				DOPosition(new Vector3(0,0,rot), isDown, null);
			}

			yield return 0;
		}
	}

	IEnumerator CheckVisibility()
	{
		while(true)
		{
			if(!sr.isVisible)
			{
				yield return new WaitForSeconds(1f);
				Destroy(gameObject);
			}

			yield return 0;
		}
	}

	public void DOPosition(Vector3 rotation, bool isDown, Action callback)
	{



		var pPosition = FindObjectOfType<Player>().defaultPosition;

		if(isDown)
		{
			var mPos = new Vector3(pPosition.x - decal, pPosition.y, pPosition.z);

			obstacleSprite.transform.localPosition = mPos;

			mPos = obstacleSprite.transform.position;
			mPos.z = 2f;

			obstacleSprite.transform.position = mPos;

			obstacleSprite.transform.localEulerAngles = new Vector3(0,0,-90);
		}
		else
		{
			var mPos = new Vector3(pPosition.x + decal, pPosition.y, pPosition.z);

			obstacleSprite.transform.localPosition = mPos;

			mPos = obstacleSprite.transform.position;
			mPos.z = 2f;

			obstacleSprite.transform.position = mPos;

			obstacleSprite.transform.localEulerAngles = new Vector3(0,0,+90);
		}

		transform.position = new Vector3(0,0,0);

		transform.eulerAngles = rotation;


		Color c = gameManager.hazardColor;
		c.a = 0f;
		sr.color = c;

	}
}


//using UnityEngine;
//using System.Collections;
//using DG.Tweening;
//
//public class ObstacleLogic : MonoBehaviourHelper 
//{
//	Circle circle;
//
//	public GameObject obstacleSprite;
//
//	SpriteRenderer sr;
//
//	public bool isVisible = false;
//
//	float decal = -1f;
//
//	void Awake()
//	{
//		circle = FindObjectOfType<Circle>();
//		obstacleSprite.SetActive(false);
//		sr = obstacleSprite.GetComponent<SpriteRenderer>();
//		isVisible = false;
//	}
//
//	public void Init(float rot, bool isDown)
//	{
//		StartCoroutine(DOStart(rot, isDown));
//	}
//
//	IEnumerator DOStart(float rot, bool isDown)
//	{
//		decal = obstacleSprite.GetComponent<SpriteRenderer>().sprite.bounds.size.y * obstacleSprite.transform.localScale.y/1.5f;
//
//		while(true)
//		{
//			DOPosition(new Vector3(0,0,rot), isDown);
//
//			if(!isVisible)
//			{
//				var d = Vector2.Distance(player.sr.transform.position,obstacleSprite.transform.position);
//
//				if(d < 0.30)
//				{
//					isVisible = true;
//					yield return new WaitForSeconds(1f);
//				}
//			}
//			else
//			{
//				if(!sr.isVisible)
//				{
//					yield return new WaitForSeconds(1f);
//					Destroy(gameObject);
//				}
//			}
//			yield return new WaitForSeconds(0.3f);
//		}
//	}
//
//	public void DOPosition(Vector3 rotation, bool isDown)
//	{
//		obstacleSprite.SetActive(true);
//
//		var pPosition = FindObjectOfType<Player>().defaultPosition;
//
//		if(isDown)
//		{
//			var mPos = new Vector3(pPosition.x - decal, pPosition.y, pPosition.z);
//
//			obstacleSprite.transform.localPosition = mPos;
//
//			mPos = obstacleSprite.transform.position;
//			mPos.z = 2f;
//
//			obstacleSprite.transform.position = mPos;
//
//			obstacleSprite.transform.localEulerAngles = new Vector3(0,0,-90);
//		}
//		else
//		{
//			var mPos = new Vector3(pPosition.x + decal, pPosition.y, pPosition.z);
//
//			obstacleSprite.transform.localPosition = mPos;
//
//			mPos = obstacleSprite.transform.position;
//			mPos.z = 2f;
//
//			obstacleSprite.transform.position = mPos;
//
//			obstacleSprite.transform.localEulerAngles = new Vector3(0,0,+90);
//		}
//
//		transform.position = new Vector3(0,0,0);
//
//		transform.eulerAngles = rotation;
//
//		obstacleSprite.GetComponent<SpriteRenderer>().color = Camera.main.backgroundColor;
//	}
//}
