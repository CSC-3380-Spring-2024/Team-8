extends Label

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func _on_mouse_entered():
	self.label_settings.font_color = Color.CORNFLOWER_BLUE
	pass # Replace with function body.


func _on_mouse_exited():
	self.label_settings.font_color = Color.WHITE
	pass # Replace with function body.
