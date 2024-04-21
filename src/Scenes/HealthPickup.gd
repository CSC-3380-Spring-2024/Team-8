extends Area2D

func _on_body_entered(body: CharacterBody2D):
	print("Body Entered")
	body.healthPoints += 0 if body.healthPoints==20 else 1
	print("Health points: %d" % body.healthPoints)
	queue_free()
