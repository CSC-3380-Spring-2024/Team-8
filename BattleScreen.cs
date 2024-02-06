using Godot;
using System;

public partial class BattleScreen : Control
{
	Node container;
	Node[] partyLabels;
	Node Dialogue;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		container = GetChild(0).GetNode("VBoxContainer").GetChild(0);
		partyLabels = new Node[Global.partyTurns.Length];
		for(int i = 0; i < partyLabels.Length; i++)
		{
			partyLabels[i] = container.GetChild(i);
			updateLabelData(i);
		}
		GD.Print(container.Name);
		Dialogue = container.GetNode("Dialogue");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void updateLabelData(int i)
	{
			Label name = (Label)partyLabels[i].GetChild(0);
			name.Show();
			name.Text = Global.partyTurns[i].fighterName;
			Label HP = (Label)partyLabels[i].GetChild(1);
			HP.Show();
			HP.Text = ("HP: " + Global.partyTurns[i].currentHP + "/" + Global.partyTurns[i].maxHP);
			Label SP = (Label)partyLabels[i].GetChild(2);
			SP.Show();
			SP.Text = ("SP: " + Global.partyTurns[i].currentMP + "/" + Global.partyTurns[i].maxMP);
	}
}
