using Godot;
using System;

public partial class enemy_template : TextureRect
{
	// Called when the node enters the scene tree for the first time.
	EnemyData data;
	int currentHealth;
	int currentSP;
	Command[] skills;
	Item[] items;
	public override void _Ready()
	{
	}
	public void New(EnemyData Data)
	{
		data = Data;
		Texture = data.sprite;
		currentHealth = data.currentHP;
		currentSP = data.currentMP;
		skills = data.commands;
		items = data.inventory;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
