extends CharacterBody2D

var is_falling = false

func _physics_process(delta):
	if is_falling:
		position.y += delta * 400

func _on_area_2d_body_entered(body: CharacterBody2D):
	if body.name == 'Player':
		print("Body Entered. Falling.")
		await get_tree().create_timer(2.5).timeout
		is_falling = true
	else:
		pass
