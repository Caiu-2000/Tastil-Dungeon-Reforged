extends MeshInstance3D

class_name DamageArea

@export var Damage : float = 1




func _on_area_3d_area_entered(area: Area3D) -> void:
	if(area is HitBox):
		var reference : HitBox = area as HitBox
		reference.Contact()
		print("Aca se llego bien")
		
