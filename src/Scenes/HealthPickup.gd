extends Area2D

func _on_body_entered(body: CharacterBody2D):
	print("Body Entered")
	State.max_health += 5
	State.current_health = min(State.current_health + 20, State.max_health)
	print("Health points: %d" % body.healthPoints)
	queue_free()
