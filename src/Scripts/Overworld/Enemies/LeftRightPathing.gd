extends CharacterBody2D


var speed = -120.0
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")
var isFacingRight = false

func _physics_process(delta):
	var HB = get_node("Hitbox")
	if HB == null:
		pass
	else:
		if not is_on_floor():
			velocity.y += gravity * delta
			
		if !$Hitbox/RayCast_Y.is_colliding() && is_on_floor():
			flip()

		if $Hitbox/RayCast_X.is_colliding() && is_on_floor():
			flip()
	
	velocity.x = speed
	move_and_slide()

func flip():
	isFacingRight = !isFacingRight
	scale.x = abs(scale.x) * -1
	
	if isFacingRight:
		speed = abs(speed)
	else:
		speed = abs(speed) * -1
