using System.Collections.Generic;
using Godot;


public partial class ComponentsHandler : Node
{
		// 1. Exporting a standard array (Best for fixed sizes)
	[Export]
	public string[] NameArray { get; set; } = System.Array.Empty<string>();

	public override void _Ready()
	{
		foreach (string name in NameArray)
		{
			GD.Print(name);
		}
	}

	/*
	[Export] private List<int> Components;

	public override void _Ready()
	{
		foreach (int component in Components)
		{
			GD.Print("hoal");
		}
	}
	*/
}
