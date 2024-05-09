using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	int healthPoints = 20;
	Boolean highJump = false;
	int jumpCount = 0;
	Boolean doubleJump = false;
	Boolean glide = false;
	
	private AnimatedSprite2D sprite;
	[Export]
	float Speed = 400.0f;

	[Export]
	float JumpHeight = -250;
	[Export]
	float timeToPeak = 0.5f;
	[Export]
	float timeToFall = 0.5f;
	[Export]
	float acceleration = 50f;
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
		sprite = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
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
		if (!IsOnFloor())
			velocity.Y += get_gravity() * (float)delta;
		else {
			if (velocity.X != 0) {
				if (velocity.X < 0) {
					sprite.FlipH = true;
				} else {
					sprite.FlipH = false;
				}
				sprite.Play("default");
			}
			else

				sprite.Stop();
			velocity.Y = 0;
		}
		// Handle doubleJump.
		if (Input.IsActionJustPressed("ui_accept") && !IsOnFloor() && jumpCount < 2 && doubleJump == true)
			if (highJump == true) {
				velocity.Y = 2 * JumpVelocity; 
				jumpCount = jumpCount + 1;}
			else {
				velocity.Y = JumpVelocity; 
				jumpCount = jumpCount + 1;}
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			if (highJump == true) {
				velocity.Y = 2 * JumpVelocity; 
				jumpCount = 1;}
			else {
				velocity.Y = JumpVelocity; 
				jumpCount = 1;}
		if (Input.IsActionJustReleased("ui_accept"))
		{
			velocity.Y = Velocity.Y/2f;
		}
		if (Input.IsActionPressed("ui_glide") && !IsOnFloor() && glide == true) 
		{
			velocity.Y = velocity.Y/2;
		}
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

