using Godot;
using System;
public partial class PlayerContact : Area2D
{

	void battleStart()
	{
		PackedScene scene = GD.Load<PackedScene>("res://src/Scenes/Battle/battle_new.tscn");
		GD.Print("Before Instantiate");
		Node loadedScene = scene.Instantiate();
		GD.Print("Instantiated");
		GetTree().Root.AddChild(loadedScene);
		QueueFree();
		//GetTree().Paused = true;
	}
	
	private void _on_body_entered(CharacterBody2D body)
	{
		if (body.Name == "Player")
		{
			GD.Print("Collided with " + body.Name);
			battleStart();
		}
			
	}

}
