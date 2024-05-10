extends Control

@onready var potions = $CanvasLayer/ColorRect/Potions

func _ready():
	potions.set_text(str($/root/State.num_potions))
	pass

func _on_potions_pressed():
	if ($/root/State.num_potions == 0 || $/root/Battle.current_player_health >= 100):
		pass
	else:
		$/root/State.num_potions -= 1
		$/root/Battle.current_player_health += randi_range(10, 15)
		$/root/Battle.set_health($/root/Battle/Interface/Node2D/Panel/HPBar, $/root/Battle.current_player_health, $/root/State.max_health)
		potions.set_text(str($/root/State.num_potions))
	pass


func _on_exit_pressed():
	queue_free()
	pass
