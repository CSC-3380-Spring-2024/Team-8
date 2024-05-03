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

	public static TurnData[] partyTurns = new TurnData[4];
	public static gameState state;
	[Export]
	public static TurnData.type active_turn = 0;
	[Export]
	public static TurnComponent involvedInBattle;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static void add_party_member(TurnData member, int partyID)
	{
		partyTurns[partyID] = member;
	}
}
