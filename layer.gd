extends ParallaxLayer


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
export(float) var speed = 80


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.



func _process(delta):
	self.motion_offset.y += speed * delta;
