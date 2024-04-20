extends Area2D


func _on_body_entered(body):
	print("Body Entered")
	body.highJump = true;
	print(body.highJump)
	queue_free()
	
