using Godot;
using System;

public partial class ChangeTexture : Sprite2D
{
	private Sprite2D sprite_node;
	private Texture2D knuckles;
	private Texture2D icon;

	public override void _Ready() {
		GD.Load("./game.tscn");
		sprite_node = GetNode<Sprite2D>("%Sprite2D2");
		knuckles = (Texture2D)GD.Load("res://7939.png");
		icon = (Texture2D)GD.Load("res://icon.svg");
	}

	public override void _Input(Godot.InputEvent @event) {
		if (@event is InputEventKey keyEvent && keyEvent.Pressed) {
			if (keyEvent.Keycode == Key.G) {
				GD.Print("IM BEING PRESSED");
				if (sprite_node.Texture == knuckles) {
					sprite_node.Texture = icon;
				}
				else {
					sprite_node.Texture = knuckles;
				}
			}
		}
	}
}
