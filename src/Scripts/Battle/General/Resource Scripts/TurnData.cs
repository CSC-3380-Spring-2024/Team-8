using Godot;
using System;
using System.Data;
[GlobalClass]
public partial class TurnData : Resource
{

	[Export] public String fighterName;
	[Export] public int Level = 1;
	public enum type{
		PLAYER, ENEMY
	}
	public type TurnType = type.PLAYER;
	[Export] public int Speed;
	[Export] public int Attack;
	[Export] public int PhysDefense;
	[Export] public int MagicDefense;
	[Export] public int maxHP;
	[Export] public int currentHP;
	[Export] public int maxMP;
	[Export] public int currentMP;
	[Export] public int maxCommands;
	[Export] public Command[] commands;
	[Export] int inventorySize = 12;
	[Export] public Item[] inventory;

	public int getHP() {
		return this.currentHP;
	}
}
