using Godot;
using Godot.NativeInterop;
using System;

public partial class ScoreManager : Node
{
	private int _score = 0;
	private int _highScore = 0;
	public static ScoreManager Instance { get; private set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static int GetScore()
	{
		return Instance._score;
	}

	public static int GetHighScore()
	{
		return Instance._highScore;
	}

	public static void SetScore(int value)
	{
		Instance._score = value;
		if (Instance._score > Instance._highScore)
		{
			Instance._highScore = Instance._score;
		}
		GD.Print($"Score: {Instance._score}, High Score: {Instance._highScore}");
	}

	public static void ResetScore()
	{
		SetScore(0);
	}

	public static void IncrementScore()
	{
		SetScore(GetScore() + 1);
	}
}
