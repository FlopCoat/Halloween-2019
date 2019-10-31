using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager gm;
	public static Transform cam;

	public int score;
	public TextMeshProUGUI scoreText;

	private void Awake()
	{
		if (!gm)
		{
			gm = this;
		}
	}

	private void Start()
	{
		scoreText.text = score.ToString();
	}

	public void AddScore()
	{
		score++;
		scoreText.text = score.ToString();
	}
}