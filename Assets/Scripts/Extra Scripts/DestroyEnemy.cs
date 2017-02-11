using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DestroyEnemy : ConditionBasedBehavior {

	public AudioClip destroy_sound;
	public int number_of_points;

	// Use this for initialization
	void Start () {
		
	}

		
	public override void OnConditionSatisfied()
	{
		SoundManager.instance.PlaySingle (destroy_sound);
		ScoreManager.instance.IncreaseScore (number_of_points);
		GameManager.instance.RemoveEnemy ();
		Destroy(gameObject);
	} 
		
}

#if UNITY_EDITOR
[CustomEditor(typeof(DestroyEnemy))]
public class DestroyEnemyEditor : ConditionBasedEditor {

}
#endif

