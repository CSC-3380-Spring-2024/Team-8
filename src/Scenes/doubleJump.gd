extends Area2D


func _on_body_entered(body):
	print("Body Entered")
	body.doubleJump = true;
	print(body.doubleJump)
	queue_free()
	
