using Godot;
using System;
[GlobalClass]
public partial class HitBox : Area3D
{
	[Export] private Node Reference;
	private IDamagable damagable;

	public override void _Ready()
	{
		
		damagable = Reference as IDamagable;
	
	}

	public void Contact()
	{
		
		damagable?.ApplyDamage(1);
	}

}
