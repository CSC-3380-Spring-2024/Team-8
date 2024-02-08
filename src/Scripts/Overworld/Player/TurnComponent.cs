using Godot;
using System;

public partial class TurnComponent : Node
{
	[Export]
	public int partyID;

	[Export]
	public TurnData turnData;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(partyID == 0)
		{
			Global.add_party_member(turnData, 0);
		}
	}
}
