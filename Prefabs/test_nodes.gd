extends Node
class_name TestNode

@export var nodo : MovementComponent 


func _process(delta: float) -> void:
	nodo.move(Vector3(1,0,0))
