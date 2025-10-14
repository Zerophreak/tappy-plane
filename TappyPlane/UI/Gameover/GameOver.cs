using Godot;
using System;

public partial class GameOver : Control
{

	[Export] private Label _gameOverLabel;
	[Export] private Label _spaceLabel;
	[Export] private AudioStreamPlayer _gameOverSound;
	[Export] private Timer _timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalManager.Instance.OnPlaneDied += OnplaneDied;

		_timer.Timeout += OnTimerTimeOut;
	}

    public override void _ExitTree()
    {
		SignalManager.Instance.OnPlaneDied -= OnplaneDied;
    }


	public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("fly") && _spaceLabel.Visible)
        {
			GameManager.LoadMain();
        }
    }

	private void OnTimerTimeOut()
    {
		_gameOverLabel.Hide();
		_spaceLabel.Show();
    }


    private void OnplaneDied()
    {
		_timer.Start();
		Show();
		_gameOverSound.Play();
    }

    
}
