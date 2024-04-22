using Godot;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public partial class party_panels : Node2D
{
	Godot.Collections.Array<Node> allies = new Godot.Collections.Array<Node>();
	int index = 0;
	bool selectState = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Adds Panel1-Panel4 into array
		allies.Add(GetChild(1));
		allies.Add(GetChild(2));
		allies.Add(GetChild(3));
		allies.Add(GetChild(4));
		allies[0].GetNode<TextureRect>("Focus").Show();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override async void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept") && selectState == false) {
			GD.Print("Select action");
			selectState = true;
			allies[index].GetNode<TextureRect>("Focus").Hide();
			allies[index].GetNode<NinePatchRect>("ActionMenu").Show();
		}


		if (Input.IsActionJustPressed("ui_cancel") && selectState == true) {
				GD.Print("Canceled selection");
				selectState = false;
				allies[index].GetNode<TextureRect>("Focus").Show();
				allies[index].GetNode<NinePatchRect>("ActionMenu").Hide();
				 
			}
		
		if (Input.IsActionJustPressed("ui_left") && selectState == false) {
			GD.Print("Pressed LEFT");
			if (index > 0) {
				index -= 1;
				switch_focus(index, index+1);
			}
		}
		
		if (Input.IsActionJustPressed("ui_right") && selectState == false) {
			GD.Print("Pressed RIGHT");
			if (index < allies.Count() - 1) {
				index += 1;
				switch_focus(index, index-1);
			}
		}
	}

	void switch_focus(int x, int y)
	{
		allies[x].GetNode<TextureRect>("Focus").Show();
		allies[y].GetNode<TextureRect>("Focus").Hide();
	}

}
