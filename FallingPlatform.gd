extends CharacterBody2D

var is_falling = false
var counter = 0

func _physics_process(delta):

	if is_falling:
		if counter > 50:
			queue_free()
		position.y += delta * 400
		counter += 1

#func _on_body_entered(body: CharacterBody2D):
#	if body.name == 'Player':
#		print("Body Entered. Falling.")
#		await get_tree().create_timer(2.5).timeout
#		is_falling = true
#	else:
#		pass

