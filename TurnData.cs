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
	[Export]
	public type TurnType;
	[Export] public int Speed;
	[Export] public int Attack;
	[Export] public int Defense;
	[Export] public int maxHP;
	[Export] public int currentHP;
	[Export] public int maxMP;
	[Export] public int currentMP;
	[Export] public int maxCommands;
	[Export] Command[] commands;
	[Export] int inventorySize = 12;
	[Export] Item[] inventory;
}
