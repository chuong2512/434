using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using System;

/// <summary>
/// Class in charge to handle UI elements.
/// </summary>
public class CanvasManager : MonoBehaviour 
{
	public CanvasGroup canvasGroupStart;
	public CanvasGroup canvasGroupInGame;
	public Text bestScoreText;
	public Text lastScoreText;

	void Awake()
	{
		UpdateText();
	}

	void Start()
	{
		canvasGroupInGame.alpha = 0;
		canvasGroupStart.alpha = 0.8f;
	}

	void UpdateText()
	{
		bestScoreText.text = "BEST " + Util.GetBestScore().ToString();
		lastScoreText.text = "LAST " + Util.GetLastScore().ToString();
	}

	public void OnStartGame(Action complete)
	{
		UpdateText();

		canvasGroupInGame.DOFade(0,0.01f)
			.SetEase(Ease.Linear);

		canvasGroupStart.DOFade(0,0.5f)
			.SetDelay(0.2f)
			.SetEase(Ease.Linear)
			.OnComplete(() => {

			canvasGroupStart.alpha = 0;

			canvasGroupStart.gameObject.SetActive(false);

			canvasGroupInGame.DOFade(0.8f,1).SetEase(Ease.Linear);

			if(complete!=null)
				complete();
		});
	}

	public void OnGameOver(Action complete)
	{
		UpdateText();

		canvasGroupStart.gameObject.SetActive(true);

		canvasGroupInGame.DOFade(0,0.2f).SetEase(Ease.Linear);

		canvasGroupStart.DOFade(0.8f,1).SetEase(Ease.Linear).OnComplete(() => {

			canvasGroupStart.alpha = 1;

			if(complete!=null)
				complete();
		});
	}

	public void OnClickedStart()
	{
		FindObjectOfType<CameraManager>().DOStart(FindObjectOfType<GameManager>().DOStart);
		OnStartGame(null);
		FindObjectOfType<Player>().ActivateTouchControl();

	}
}
