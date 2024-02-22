extends "res://addons/MetroidvaniaSystem/Template/Scripts/MetSysGame.gd"

static var camera: Camera2D
func adjustCamera() -> void:
	MetSys.get_current_room_instance().adjust_camera_limits(camera)
func setCamera(Camera: Camera2D) -> void:
	camera = Camera
func loadRoom(path: String, parent) -> void:
	load_room(path)
func setPlayer(p_player: Node2D) -> void:
	set_player(p_player)
func addModule(module_name: String) -> void:
	add_module(module_name)
func initRoom():
	MetSys.get_current_room_instance().adjust_camera_limits($Player/Camera2D)
	player.on_enter()
func resetState() -> void:
	MetSys.reset_state()
func roomLoaded() -> void:
	room_loaded.connect(initRoom, CONNECT_DEFERRED)
