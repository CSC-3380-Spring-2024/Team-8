using Godot;
using System;

public partial class ChangeTexture : Sprite2D
{
	private Sprite2D sprite_node;
	private Texture2D sprite1;
	private Texture2D icon;

	public override void _Ready() {
		GD.Load("./game.tscn");
		sprite_node = GetNode<Sprite2D>("%Sprite2D2");
		sprite1 = (Texture2D)GD.Load("res://src/Assets/proto/sprite1.png");
		icon = (Texture2D)GD.Load("res://src/Assets/proto/icon.svg");
	}

	public override void _Input(Godot.InputEvent @event) {
		if (@event is InputEventKey keyEvent && keyEvent.Pressed) {
			if (keyEvent.Keycode == Key.G) {
				GD.Print("IM BEING PRESSED");
				if (sprite_node.Texture == sprite1) {
					sprite_node.Texture = icon;
				}
				else {
					sprite_node.Texture = sprite1;
				}
			}
		}
	}
}
