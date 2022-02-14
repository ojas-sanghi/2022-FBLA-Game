extends Area2D

export var speed : int = 2
export var moveDist : int = 100

var hit_right_extreme : bool = false
var hit_left_extreme : bool = true
onready var rightEnd = position.x + moveDist
onready var leftEnd = position.x - moveDist

func _process(delta):
	if position.x >= rightEnd:
		hit_right_extreme = true
		hit_left_extreme = false
	elif position.x <= leftEnd:
		hit_left_extreme = true
		hit_right_extreme = false
	
	if hit_right_extreme == true:
		position.x -= speed
	elif hit_left_extreme == true:
		position.x += speed
	print(hit_right_extreme)
	print(hit_left_extreme)
	print(position.x)
