extends Area2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var speed = 1000;


# Called when the node enters the scene tree for the first time.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta):
		global_position.y += -speed * delta;


func _on_bullet_area_entered(area):
	if area.is_in_group("enemies"):
		area.takeDamage(1)
		queue_free()
