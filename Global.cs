using Godot;
using System;

public partial class Global : Node
{

	public enum gameState{
		Exploration,
		Battle_Select,
		Battle_Execute,
		Pause
	}
	public static gameState state;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
