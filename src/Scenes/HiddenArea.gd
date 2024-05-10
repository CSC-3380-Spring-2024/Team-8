extends Area2D

func _physics_process(delta):
	var bodies = get_overlapping_bodies()
	var player_in_area = false
	
	for body in bodies:
		if body.name == "Player":
			player_in_area = true
			break
	
	if player_in_area:
		$AnimationPlayer.play("Show")
	else:
		$AnimationPlayer.play("Hidden")
