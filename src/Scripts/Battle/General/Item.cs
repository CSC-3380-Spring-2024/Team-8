using Godot;
using System;
[GlobalClass]
public partial class Item : Node
{
	[Export] String item_name;
	[Export] float effectStrength = 0.0f;
	enum effectType {
	health, 
	mana, 
	strength, 
	defense, 
	attack, 
	damage, 
	evasion, 
	movement,
	}
	[Export] effectType type = effectType.health;
	[Export] String description;
	enum targetType {
	SELF, 
	PARTY, 
	ALL, 
	ENEMY 
	}
	[Export] targetType target;
	int _use_command(int currentItemCount)
	{
		switch (type)
		{
			case effectType.health:
				break;
			case effectType.mana:
				break;
			case effectType.strength:
				break;
			case effectType.defense:
				break;
			case effectType.attack:
				break;
			case effectType.damage:
				break;
			case effectType.evasion:
				break;
			default:
				break;
		}

		return currentItemCount - 1;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
