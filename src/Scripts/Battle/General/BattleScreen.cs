using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class BattleScreen : Control
{
	Node container;
	static Node[] partyLabels;
	Node Dialogue;

	TurnData[] enemyData;
	ActionManager actionManager;
	Button firstButton;
	public void New(TurnData[] EnemyData)
	{
		enemyData = EnemyData;
	}

	enum menuState{
		START,
		SELECT,
		ACTION,
		WIN,
		LOSE
	}

	menuState state = menuState.START;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		while(enemyData == null)
		{
			GD.PrintErr("Enemy data is null");
		}
		container = GetChild(0).GetNode("VBoxContainer").GetChild(0);
		partyLabels = new Node[Global.partyTurns.Length];
		for(int i = 0; i < partyLabels.Length; i++)
		{
			partyLabels[i] = container.GetChild(i);
			UpdateLabelData(i);
		}
		GD.Print(container.Name);
		state = menuState.START;
		Dialogue = container.GetParent().GetNode("Panel").GetNode("DialogueBox");
		GD.Print("Dialogue box: " + Dialogue);
		Label d_label = (Label)Dialogue.GetNode("Label");
		GD.Print(d_label);
		GD.Print(menuDialogue());
		d_label.Text = menuDialogue();
		actionManager = (ActionManager)GetNode("Action Manager");
		firstButton = (Button)Dialogue.GetNode("Buttons").GetChild(0);
	}


	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if(Input.IsActionJustPressed("ui_accept") & state == menuState.START)
		{
			state = menuState.SELECT;
			Label d_label = (Label)Dialogue.GetNode("Label");
			d_label.Text = menuDialogue();
			firstButton.GrabFocus();
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static void UpdateLabelData(int i)
	{	
		if(Global.partyTurns[i] != null)
		{
			Label name = (Label)partyLabels[i].GetChild(0);
			name.Show();
			name.Text = Global.partyTurns[i].fighterName;
			GD.Print("Showing text " + i);
			Label HP = (Label)partyLabels[i].GetChild(1);
			HP.Show();
			HP.Text = ("HP: " + Global.partyTurns[i].currentHP + "/" + Global.partyTurns[i].maxHP);
			Label SP = (Label)partyLabels[i].GetChild(2);
			SP.Show();
			SP.Text = ("SP: " + Global.partyTurns[i].currentMP + "/" + Global.partyTurns[i].maxMP);
		}
	}

	String menuDialogue()
	{
		GD.Print(state);//prints
		HFlowContainer buttons = (HFlowContainer)Dialogue.GetNode("Buttons");
		GD.Print(buttons);//does not print
		Label d_Label = (Label)Dialogue.GetNode("Label");
		switch(state){
			case menuState.START:
				d_Label.Show();
				buttons.Hide();
				return startBattle();
			case menuState.SELECT:
				d_Label.Hide();
				buttons.Show();
				return null;
			case menuState.ACTION:
				d_Label.Show();
				buttons.Hide();
				//implement action queue
				return null;
			case menuState.WIN:
				d_Label.Show();
				buttons.Hide();
				//implement EXP and money
				return null;
			case menuState.LOSE:
				d_Label.Show();
				buttons.Hide();
				return "YOUR PARTY WAS WIPED OUT";
			default:
				return null;
		}
	}
	String startBattle(){
		GD.Print(enemyData.Length);
		if(enemyData.Length <= 1)
		{
			return "An enemy appears";
		}
		else if(enemyData.Length > 1)
		{
			return "Some Enemies appear";
		}
		else
		{
			return null;
		}
	}
}
