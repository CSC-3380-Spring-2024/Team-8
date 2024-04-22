extends Control
	
signal textbox_closed

@export var enemy: Resource

var current_player_health = 0
var current_enemy_health = 0
var is_defending = false


func _ready():
	display_text("Bob wants to fight! What will you do?")
	
	set_health($Interface/Node2D/Panel/HPBar, State.current_health, State.max_health)
	set_health($Interface/Node2D/Panel2/HPBar, State.current_health, State.max_health)
	set_health($Interface/Node2D/Panel3/HPBar, State.current_health, State.max_health)
	set_health($Interface/Node2D/Panel4/HPBar, State.current_health, State.max_health)
	set_health($Interface/Node2D/EnemyContainer/HPBar2, enemy.health, enemy.health)
	
	current_player_health = State.current_health
	current_enemy_health = enemy.health

func _input(_event):
	if (Input.is_action_just_pressed("ui_accept") or Input.is_mouse_button_pressed(MOUSE_BUTTON_LEFT) and $Interface/Node2D/Textbox.visible):
		$Interface/Node2D/Textbox.hide()
		emit_signal("textbox_closed")
	#if (Input.is_action_just_pressed("ui_cancel") and $Interface/Node2D/Textbox.hidden):
		#$Interface/Node2D/Textbox.show()
	

func display_text(text):
	$Interface/Node2D/Textbox.show()
	$Interface/Node2D/Textbox/Label.text = text

func enemy_turn():
	display_text("%s charges at you!" %enemy.name)
	await textbox_closed
	
	if is_defending:
		is_defending = false
		display_text("You blocked %s's attack!" %enemy.name)
		await textbox_closed
		display_text("What will you do next?")
		await textbox_closed
	else:
		current_player_health = max(0, current_player_health - enemy.damage)
		set_health($Interface/Node2D/Panel/HPBar, current_player_health, State.max_health)
		display_text("%s dealt a whopping %d damage to you" %[enemy.name, enemy.damage])
		await textbox_closed
		if current_player_health == 0:
			display_text("Oh no, %s defeated you..." %enemy.name)
			await textbox_closed
			display_text("We'll beat him next time")
			await textbox_closed
			get_tree().change_scene_to_file("res://src/Scenes/game.tscn")
		else:
			display_text("What will you do next?")
			await textbox_closed
	
func _on_flee_pressed():
	display_text("We'll get him next time...")
	await textbox_closed
	get_tree().change_scene_to_file("res://src/Scenes/game.tscn")
	

func set_health(progress_bar, health, max_health):
	progress_bar.max_value = max_health
	progress_bar.value = health
	progress_bar.get_node("Label").text = "HP: %d/%d" % [health, max_health]


func _on_attack_pressed():
	display_text($Interface/Node2D/Panel.get_node("Name").text + " swings at Bob!")
	await textbox_closed
	current_enemy_health = max(0, current_enemy_health - State.damage)
	set_health($Interface/Node2D/EnemyContainer/HPBar2, current_enemy_health, enemy.health)
	display_text("You dealt %d damage to %s" %[State.damage, enemy.name])
	await textbox_closed
	
	if current_enemy_health == 0:
		display_text("Congratulations, you defeated %s!" %enemy.name)
		await textbox_closed
		$AnimationPlayer.play("enemy_died")
		
	
	enemy_turn()
	
func _on_defend_pressed():
	is_defending = true
	display_text("You prepare to defend")
	await textbox_closed
	enemy_turn()



#WIP
func _on_attack_2_pressed():
	display_text($Interface/Node2D/Panel2.get_node("Name").text + " swings at Bob!")
	await textbox_closed
	current_enemy_health = max(0, current_enemy_health - State.damage)
	set_health($Interface/Node2D/EnemyContainer/HPBar2, current_enemy_health, enemy.health)
	display_text("You dealt %d damage to %s" %[State.damage, enemy.name])
	await textbox_closed
	enemy_turn()


func _on_attack_3_pressed():
	display_text($Interface/Node2D/Panel3.get_node("Name").text + " swings at Bob!")
	await textbox_closed
	current_enemy_health = max(0, current_enemy_health - State.damage)
	set_health($Interface/Node2D/EnemyContainer/HPBar2, current_enemy_health, enemy.health)
	display_text("You dealt %d damage to %s" %[State.damage, enemy.name])
	await textbox_closed
	enemy_turn()


func _on_attack_4_pressed():
	display_text($Interface/Node2D/Panel4.get_node("Name").text + " swings at Bob!")
	await textbox_closed
	current_enemy_health = max(0, current_enemy_health - State.damage)
	set_health($Interface/Node2D/EnemyContainer/HPBar2, current_enemy_health, enemy.health)
	display_text("You dealt %d damage to %s" %[State.damage, enemy.name])
	await textbox_closed
	enemy_turn()



