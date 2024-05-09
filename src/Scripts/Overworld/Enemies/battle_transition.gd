extends Node


@export var start_scene: String

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.


func _on_body_entered(body):
	if body.name == "Player":
		print("Collided with " + body.name)
		get_tree().change_scene_to_file("res://src/Scenes/Battle/battle_new.tscn")
	elif body.name == "FallingPlatform":
		print("bobbo fall down go boom")
		get_parent().queue_free()
	else:
		pass
