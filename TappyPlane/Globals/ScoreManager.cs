using Godot;
using Godot.NativeInterop;
using System;

public partial class ScoreManager : Node
{
	private uint _score = 0;
	private uint _highScore = 0;

	private const string SCORE_FILE = "user://TappyPlane.save";
	public static ScoreManager Instance { get; private set; }


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

    public override void _ExitTree()
    {
		SaveScoreToFile();
	}


	public static uint GetScore()
	{
		return Instance._score;
	}

	public static uint GetHighScore()
	{
		return Instance._highScore;
	}

	public static void SetScore(uint value)
	{
		Instance._score = value;
		if (Instance._score > Instance._highScore)
		{
			Instance._highScore = Instance._score;
		}
		GD.Print($"Score: {Instance._score}, High Score: {Instance._highScore}");
		SignalManager.EmitOnScored();
	}


	public static void ResetScore()
	{
		SetScore(0);
	}

	public static void IncrementScore()
	{
		SetScore(GetScore() + 1);
	}

	private void LoadScoreFromFile()
	{
		using FileAccess file = FileAccess.Open(SCORE_FILE, FileAccess.ModeFlags.Read);
		if (file != null)
		{
			_highScore = file.Get32();
		}
	}
	private void SaveScoreToFile()
	{
		using FileAccess file = FileAccess.Open(SCORE_FILE, FileAccess.ModeFlags.Write);
		if (file != null)
		{
			file.Store32(_highScore);
		}
	}
}
