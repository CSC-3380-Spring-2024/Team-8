extends Area2D


# Called when the node enters the scene tree for the first time.
func _on_body_entered(body):
	if body.name == 'Player':
		print("Body Entered. Falling.")
		await get_tree().create_timer(2.5).timeout
		get_parent().is_falling = true
	else:
		pass
	
