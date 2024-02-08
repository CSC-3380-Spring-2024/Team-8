using Godot;
using System;

public partial class PlayerMove : CharacterBody2D
{
	[Export]
	float Speed = 300.0f;

	[Export]
	float JumpHeight = -250;
	[Export]
	float timeToPeak = 0.5f;
	[Export]
	float timeToFall = 0.5f;
	[Export]
	float acceleration = 10f;
	[Export]
	float friction = 12f;

	float JumpVelocity;
	float JumpGravity;
	float FallGravity;

	public override void _Ready()
	{
		JumpVelocity = (2.0f * JumpHeight) / timeToPeak;
		JumpGravity = (-2.0f * JumpHeight) / (timeToPeak * timeToPeak);
		FallGravity = (-2.0f * JumpHeight) / (timeToFall * timeToFall);
	}

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	float get_gravity()
	{
		if(Velocity.Y < 0){
			return JumpGravity;
		}
		else
		{
			return FallGravity;
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		if(Global.state != Global.gameState.Exploration)
		{
			return;
		}
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += get_gravity() * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = Mathf.MoveToward(velocity.X ,direction.X * Speed, acceleration);
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, friction);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
