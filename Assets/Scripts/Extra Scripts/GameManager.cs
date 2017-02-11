using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject[] space_invaders;


	int dif;

	int active_enemies;

	// Use this for initialization
	void Start () {

		instance = this;

		dif = PlayerPrefs.GetInt("Difficulty", 3);
		active_enemies = dif;

		StartInvaders (dif);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartInvaders(int num_of_invaders)
	{
		int i = 0;

		for (i = 0; i < num_of_invaders; i++) 
		{
			space_invaders [i].SetActive (true);
		}
	}

	int ChangeDifficulty (int prev_dif)
	{
		int next_dif = 3;
		switch (prev_dif) 
		{
		case 3:
			next_dif = 5;
			break;
		case 5:
			next_dif = 9;
			break;
		case 9:
			next_dif = 14;
			break;
		case 14:
			next_dif = 14;
			break;
		}
		return next_dif;
	}

	public void EndGame (bool mode)
	{
		if (mode) {
			PlayerPrefs.SetInt ("Difficulty", ChangeDifficulty (dif));
			ScoreManager.instance.SaveScore ();
		} else 
		{
			PlayerPrefs.SetInt ("Difficulty", 3);
			ScoreManager.instance.CheckHighScore ();
		}

		StartCoroutine (DelayLoad ());
	}

	public void RemoveEnemy ()
	{
		active_enemies--;
		if (active_enemies <= 0) 
		{
			EndGame (true);
		}
	}

	IEnumerator DelayLoad()
	{
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
