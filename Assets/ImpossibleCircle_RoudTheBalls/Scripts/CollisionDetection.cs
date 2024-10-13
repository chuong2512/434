using UnityEngine;
using System.Collections;

/// <summary>
/// Class attached to the sprite child of the Player GameOBject, in charge to listen if the player collide with an obstacle
/// </summary>
public class CollisionDetection : MonoBehaviour
{
	/// <summary>
	/// Listen the collision. If collision: all the Player method DOOnTriggerEnter2D
	/// </summary>
	public void OnTriggerEnter2D(Collider2D other)
	{
		FindObjectOfType<Player>().DOOnTriggerEnter2D(other);
	}
}
