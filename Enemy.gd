extends Node2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var thing = preload('res://bulletlaser.tscn');
var hp = 1;
var speed = 100;
signal enemy_died;

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.¨

func _physics_process(delta):
	global_position.y += speed * delta


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
	
func takeDamage(damage):
	hp -= damage;
	if hp <= 0:
		queue_free();
		emit_signal("enemy_died")

func _on_Area2D_body_entered(body):
	if body.is_in_group("player"):
		takeDamage(1)
		body.takeDamage(1);
