extends Area2D


# Called when the node enters the scene tree for the first time.
func _on_body_entered(body):
	print("Body Entered")
	body.glide = true;
	print(body.glide)
	queue_free()
	
