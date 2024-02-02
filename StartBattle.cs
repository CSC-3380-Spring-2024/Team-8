using Godot;
using System;

public partial class StartBattle : Area2D
{
	TurnData[] turns;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void startBattle()
	{
		sortTurns(turns);
	}

    private TurnData[] sortTurns(TurnData[] unsortedTurns)
    {
		var arrLength = unsortedTurns.Length;
		for(int i = 0; i < arrLength; i++)
		{
			int smallest = i;
			for(int j = i++; j < arrLength; j++)
			{
				if(unsortedTurns[i].Speed > unsortedTurns[j].Speed)
				{
					unsortedTurns[i].Speed = unsortedTurns[j].Speed;
				}
			}
			TurnData tempData = unsortedTurns[smallest];
			unsortedTurns[smallest] = unsortedTurns[i];
			unsortedTurns[i] = unsortedTurns[smallest];
			
		}
        throw new NotImplementedException();
    }
	public void _on_body_entered(Node2D body)
	{
		GD.Print("body_entered");
		PackedScene scene = GD.Load<PackedScene>("res://battle.tscn");
		Node loadedScene = scene.Instantiate();
		this.AddChild(loadedScene);
	}

}
