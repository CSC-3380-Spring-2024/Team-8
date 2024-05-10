extends Node


@export var start_scene: String

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	pass


func _on_body_entered(body):
	if body.name == "Player":
		print("Collided with " + body.name)
		$/root/PlayerRef.reference = body
		get_tree().change_scene_to_file("res://src/Scenes/Battle/battle_new.tscn")
