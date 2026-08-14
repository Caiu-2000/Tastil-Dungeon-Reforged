using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }
	public static Player player;
	public override void _Ready()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			QueueFree();
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
