extends CanvasLayer


func show_message(text):
	$Message.text = text
	$Message.show()
	$MessageTimer.start()


func _on_health_pickup_body_entered(_body):
	

	$Message.text = "Health Increased by 1."
	$Message.show()
	$MessageTimer.start()


func _on_high_jump_body_entered(_body):
	
	$Message.text = "New boots. I bet you can jump twice as high."
	$Message.show()
	$MessageTimer.start()



func _on_double_jump_body_entered(_body):
	$Message.text = "Must be the shoes. Looks like you can jump in the air now."
	$Message.show()
	$MessageTimer.start()
	

func _on_glide_body_entered(_body):
	$Message.text = "I bet that'll help slow your fall."
	$Message.show()
	$MessageTimer.start()
	


func _on_message_timer_timeout():
	$Message.hide()
