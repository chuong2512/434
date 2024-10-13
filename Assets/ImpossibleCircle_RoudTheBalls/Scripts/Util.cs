using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Utility class.
/// </summary>
public static class Util
{
	static System.Random random = new System.Random();

	public static double GetRandomNumber(double minimum, double maximum)
	{ 
		return random.NextDouble() * (maximum - minimum) + minimum;
	}

	public static float GetRandomNumber(float minimum, float maximum)
	{ 
		return (float)random.NextDouble() * (maximum - minimum) + minimum;
	}

	public static void SetLastScore(int score)
	{
		PlayerPrefs.SetInt("_LASTSCORE",score);

		SetBestScore(score);

		PlayerPrefs.Save();
	}

	static void SetBestScore(int score)
	{
		int b = GetBestScore();

		if(score > b)
			PlayerPrefs.SetInt("_BESTSCORE",score);
	}

	public static int GetBestScore()
	{
		return PlayerPrefs.GetInt("_BESTSCORE",0);
	}

	public static int GetLastScore()
	{
		return PlayerPrefs.GetInt("_LASTSCORE",0);
	}

}
