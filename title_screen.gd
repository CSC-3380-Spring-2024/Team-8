extends Control

# Called when the node enters the scene tree for the first time.
func _ready():
	self.position = get_viewport_rect().size/2
	pass # Replace with function body.


func _on_play_pressed():
	get_tree().change_scene_to_file("res://src/Scenes/game.tscn")
	pass # Replace with function body.


func _on_exit_pressed():
	get_tree().quit()
	pass # Replace with function body.
