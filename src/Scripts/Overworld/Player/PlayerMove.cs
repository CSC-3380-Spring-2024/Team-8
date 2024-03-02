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
	[Export]
	float VariableJumpHeight = -125; 

	float JumpVelocity;
	float JumpGravity;
	float FallGravity;
	float VariableJumpGravity;

	public override void _Ready()
	{
		JumpVelocity = (2.0f * JumpHeight) / timeToPeak;
		JumpGravity = (-2.0f * JumpHeight) / (timeToPeak * timeToPeak);
		FallGravity = (-2.0f * JumpHeight) / (timeToFall * timeToFall);
		VariableJumpGravity = (JumpVelocity * JumpVelocity) / (2 * VariableJumpHeight);
		FloorSnapLength = 0;
		GD.Print(FloorSnapLength);
	}



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
		velocity.Y += get_gravity() * (float)delta;
		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;
		if (Input.IsActionJustReleased("ui_accept"))
		{
			velocity.Y = Velocity.Y/2f;
		}
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("ui_left", "ui_right");
		
		//Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != 0)
		{
			velocity.X = Mathf.MoveToward(velocity.X ,direction * Speed, acceleration);
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, friction);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
