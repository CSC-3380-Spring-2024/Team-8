using Godot;
using System;
using System.Collections;

public partial class PathLogic : PathFollow2D
{
	private PathFollow2D path_node;
	private Area2D area_node;
	private Sprite2D enemy;
	private bool flip;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Load("game.tscn");
		path_node = GetNode<PathFollow2D>("%PathFollow2D");
		flip = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Global.state == Global.gameState.Exploration)
		{
			switch (flip)
			{
				case true:
					path_node.Progress += 5;
					if (path_node.ProgressRatio > 0.9)
					{
						flip = false;
					}
					break;
				case false:
					path_node.Progress -= 5;
					if (path_node.ProgressRatio < 0.1)
					{
						flip = true;
					}
					break;
			}
		}
	}
}
