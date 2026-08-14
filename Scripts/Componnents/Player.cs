using Godot;
using System;


public partial class Player: Entity
{
	[Export] public Marker3D CamMount;

	public override void _Ready()
	{
		base._Ready();
		GameManager.player = this;
	}
}
