using UnityEngine;
using System.Collections;
using DG.Tweening;

/// <summary>
/// Class in charge to draw the circles.
/// </summary>
public class Circle : MonoBehaviour
{
	GameManager gameManager;

	int segments = 200;
	LineRenderer line;

	private float radius;
	private float width = 0.3f;


	Transform playerSpriteTransform;

	void Awake()
	{
		this.playerSpriteTransform = FindObjectOfType<Player>().sr.transform;
		this.gameManager = FindObjectOfType<GameManager>();
	}

	public void SetRadius(float radius)
	{
		this.radius = radius;
	}

	public float GetRadius()
	{
		return this.radius;
	}

	public float GetWidth()
	{
		return this.width;
	}

	public void DOParticle()
	{
		float angle = 20f;
		float z = 90f;
		float x;
		float y;

		for (int i = 0; i < (segments + 2); i++)
		{
			int sign = 1;

			if(playerSpriteTransform.localPosition.x > 0)
			{
				sign = 1;
			}
			else
			{
				sign = -1;
			}

			x = Mathf.Sin (Mathf.Deg2Rad * angle) * (GetRadius() + sign * width / 2f);
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * (GetRadius() + sign * width / 2f);

			angle += (360f / segments);

			SpawnManager.instance.SpawnParticle(gameManager.backgroundColor, new Vector3(x,y,z), new Vector3(0,0,-angle));
		}
	}

	public void DOStart ()
	{
		line = gameObject.GetComponent<LineRenderer>();

		line.SetVertexCount (segments + 2);
		line.useWorldSpace = false;
		CreatePoints ();
		line.material.color = gameManager.circleColor;
		line.SetWidth(width,width);
	}

	public void CreatePoints ()
	{
		float angle = 20f;
		float z = 0f;
		float x;
		float y;

		for (int i = 0; i < (segments + 2); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * radius;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * radius;

			line.SetPosition (i,new Vector3(x,y,z) );

			angle += (360f / segments);
		}
	}
}