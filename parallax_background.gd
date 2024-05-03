extends ParallaxBackground

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	self.scroll_offset.x += delta * 50
	pass
