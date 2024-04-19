using Godot;
using System;
using System.Linq;

public partial class StartBattle : Area2D
{

	TurnData[] turns;
	[Export]
	EnemyData[] EnemyTurns;

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
		GD.Print("body_entered");
		Global.state = Global.gameState.Battle_Select;
		PackedScene scene = GD.Load<PackedScene>("res://src/Scenes/Template/battle.tscn");
		turns = EnemyTurns.Concat(Global.partyTurns).ToArray();
		turns = turns.Where(x => x != null).ToArray();
		GD.Print(turns.Length);
		turns = sortTurns(turns);
		GD.Print(turns);
		Node loadedScene = scene.Instantiate();
		BattleScreen gameScreen = (BattleScreen)loadedScene;
		gameScreen.New(EnemyTurns);
		this.AddChild(loadedScene);
		loadEnemies(gameScreen.GetChild(0).GetNode("VBoxContainer").GetNode("Panel").GetNode("HBoxContainer"));
		sortTurns(turns);
	}
	void loadEnemies(Node Panel)
	{
		for(int i = 0; i < EnemyTurns.Length; i++){
			GD.Print(i);
			GD.Print(EnemyTurns[i].template.ResourcePath);
			PackedScene scene = GD.Load<PackedScene>(EnemyTurns[i].template.ResourcePath);
			Node LoadedScene = scene.Instantiate();
			enemy_template template = (enemy_template)LoadedScene;
			Panel.AddChild(LoadedScene);
			template.New(EnemyTurns[i]);
		}
		
	}

	private TurnData[] sortTurns(TurnData[] unsortedTurns)
	{
		var arrLength = unsortedTurns.Length;
		for(int i = 0; i < arrLength; i++)
		{
			GD.Print(i);
			int smallest = i;
			for(int j = 1; j < arrLength; j++)
			{
				GD.Print(j);
				if(unsortedTurns[i].Speed > unsortedTurns[j].Speed)
				{
					unsortedTurns[i].Speed = unsortedTurns[j].Speed;
				}
			}
			TurnData tempData = unsortedTurns[smallest];
			unsortedTurns[smallest] = unsortedTurns[i];
			unsortedTurns[i] = unsortedTurns[smallest];
			
		}
		return unsortedTurns;
	}
	public void _on_body_entered(CharacterBody2D body)
	{
		startBattle();
		Global.involvedInBattle = (TurnComponent)body.GetChild(4);
	}
}
