extends Node2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var enemy = preload('res://Enemy.tscn');
var spawnpos = null;

# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	spawnpos = $SpawnLocations.get_children();
	
func spawnenemy():
	var index = randi() % spawnpos.size();
	var en = enemy.instance();
	en.global_position = spawnpos[index].global_position;
	en.connect("enemy_died", get_tree().current_scene, "add_score")
	add_child(en);
	


func _on_SpawnTimer_timeout():
	spawnenemy()
