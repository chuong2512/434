using UnityEngine;
using System.Collections;
#if APPADVISORY_LEADERBOARD
using AppAdvisory.social;
#endif

/// <summary>
/// Class attached to the leaderboard button. Works only on mobile (iOS & Android), with Very Simple Leaderboard : http://u3d.as/qxf
/// </summary>
public class ButtonLeaderboard : MonoBehaviour 
{
	void Awake()
	{
		#if !UNITY_ANDROID__ && !UNITY_IOS
		gameObject.SetActive(false);
		#endif
	}
	/// <summary>
	/// If player clics on the leaderbord button, we call this method. Works only on mobile (iOS & Android) if using Very Simple Leaderboard by App Advisory : http://u3d.as/qxf
	/// </summary>
	public void OnClickedOpenLeaderboard()
	{
		#if APPADVISORY_LEADERBOARD
		LeaderboardManager.ShowLeaderboardUI();
		#else
		print("OnClickedOpenLeaderboard : works only on mobile (iOS & Android), with Very Simple Leaderboard : http://u3d.as/qxf");
		#endif
	}
}
