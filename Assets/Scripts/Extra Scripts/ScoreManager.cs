using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public Text score_1p_text;
	public Text score_2p_text;
	public Text high_score_text;

	private int game_score = 0;

	public static ScoreManager instance;

	// Use this for initialization
	void Start () {

		instance = this;



		game_score = PlayerPrefs.GetInt ("ActiveScore", 0);
		score_2p_text.text = 0.ToString();
		high_score_text.text = PlayerPrefs.GetInt ("HighScore", 0).ToString();

	}
	
	// Update is called once per frame
	void Update () {

		score_1p_text.text = game_score.ToString ();
		
	}

	public void IncreaseScore(int score)
	{
		game_score = game_score + score;
	}

	public void SaveScore()
	{
		PlayerPrefs.SetInt ("ActiveScore", game_score);
	}

	public void CheckHighScore()
	{
		if (game_score > PlayerPrefs.GetInt ("HighScore")) 
		{
			PlayerPrefs.SetInt ("HighScore", game_score);
			PlayerPrefs.SetInt ("ActiveScore", 0);
		}
	}
}
