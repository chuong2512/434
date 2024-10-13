using UnityEngine;
using System.Collections;

/// <summary>
/// Class in charge to play sound in the game.
/// </summary>
public class SoundManager : MonoBehaviour 
{
	AudioSource _audioSource;
	AudioSource audioSource
	{
		get
		{
			if(_audioSource == null)
				_audioSource = FindObjectOfType<AudioSource>();

			return _audioSource;
		}
	}

	[SerializeField] private AudioClip soundFail;
	[SerializeField] private AudioClip soundTouch;

	public void PlayFail()
	{
		audioSource.PlayOneShot (soundFail,1f);
	}

	public void PlayTouch()
	{
		audioSource.PlayOneShot (soundTouch,1f);
	}

}
