using Godot;
using System;
using System.Numerics;

public partial class enemy : CharacterBody2D
{
	float speed = -120.0f;
	float scaler = 0;
	float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	bool isFacingRight = false;
	private Godot.Collections.Array<Node> movingBodies = new Godot.Collections.Array<Node>();

	public override void _Ready()
	{
		movingBodies = GetTree().GetNodesInGroup("Moving Bodies");
	}

	//ORIGINAL PLAYER POS = 144, 433
	public override void _PhysicsProcess(double delta)
	{
		Godot.Vector2 velocity = Velocity;
		Godot.Vector2 scale = Scale;
		RayCast2D ray_Y = GetNode<RayCast2D>("Hitbox/RayCast_Y");
		RayCast2D ray_X = GetNode<RayCast2D>("Hitbox/RayCast_X");
		

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}
		
		if (!ray_Y.IsColliding() && IsOnFloor()) {
			scale.X = Math.Abs(scale.X) * -1;
			flip();
		}

		if (ray_X.IsColliding() && IsOnFloor()) {
			scale.X = Math.Abs(scale.X) * -1;
			flip();
		}
		
		Scale = scale;
		velocity.X = speed;
		Velocity = velocity;
		MoveAndSlide();
	}

	void flip()
	{
		isFacingRight = !isFacingRight;
		
		if (isFacingRight) { 
			speed = Math.Abs(speed);
		}
		else {
			speed = Math.Abs(speed) * -1;
		}
	}

	// Start battle on player contact
	private void _on_hitbox_body_entered(CharacterBody2D body)
	{
		if (body.Name == "Player") {
			//Pause physics for all Nodes in "Moving Bodies" group
			foreach (Node node in movingBodies)
			{
				node.SetPhysicsProcess(false);
			}
			GD.Print("Loading scene...");

			//REMEMBER TO CHANGE PATH WHEN MOVING FILES !!
			PackedScene scene = GD.Load<PackedScene>("res://src/Scenes/Battle/battle_new.tscn");

			Node sceneInstance = scene.Instantiate();
			this.AddChild(sceneInstance);
			GD.Print("Scene loaded");
			GD.Print("Starting battle...");
		}
		
	}

}

