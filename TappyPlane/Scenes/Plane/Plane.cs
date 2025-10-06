using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Plane : CharacterBody2D
{
	const float GRAVITY = 800.0f;
	const float POWER = -450.0f;

	[Export] private AnimatedSprite2D _planeSprite;
	[Export] private AnimationPlayer _animationPlayer;

	[Signal] public delegate void OnPlaneDiedEventHandler(); 

	public override void _Ready()
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += GRAVITY * (float)delta;

		if (Input.IsActionJustPressed("fly"))
		{
			velocity.Y = POWER;
			_animationPlayer.Play("power");

		}

		Velocity = velocity;
		MoveAndSlide();

		if (IsOnFloor())
		{
			Die();
		}

	}

	public void Die()
	{
		SetPhysicsProcess(false);
		_planeSprite.Stop();
		//GD.Print("Die");
		EmitSignal(SignalName.OnPlaneDied);
    }

}
