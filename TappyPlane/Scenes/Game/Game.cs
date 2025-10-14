using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;
	//[Export] private Node2D _pipesHolder;
	[Export] private Timer _spawnTimer;
	[Export] private PackedScene _pipesScene;
	// [Export] private Plane _plane;

	//private bool _gameOver = false; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_spawnTimer.Timeout += SpawnPipes;
		SignalManager.Instance.OnPlaneDied += GameOver;

		//GD.Print("Game");

		ScoreManager.ResetScore();
		SpawnPipes();
	}

	public override void _Process(double delta)
	{
		// if(Input.IsActionJustPressed("fly") && _gameOver)
		// {
		//		ChangeToMain();
		// }

		 if (Input.IsKeyPressed(Key.Q))
		 {
				ChangeToMain();
		 }
	 }

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= GameOver;
	}

	// REFEREnce
	//private void StopPipes()
	//{ 
	//	_spawnTimer.Stop();
	// REFEREMCE ONLY 
	// 	foreach (Pipes pipe in _pipesHolder.GetChildren())
	// {
	//		pipe.SetProcess(false);
	// }
	//}

	private void GameOver()
	{

		_spawnTimer.Stop();
		//_gameOver = true;
	}
	
	private void ChangeToMain()
	{
		GameManager.LoadMain();
	}
	public float GetSpawnY()
	{
		return (float)GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
	}
	private void SpawnPipes()
	{
		Pipes np = _pipesScene.Instantiate<Pipes>();
		AddChild(np);
		np.Position = new Vector2(_spawnLower.Position.X, GetSpawnY());
	}
	
}
