using Godot;
using System;

public partial class MainCanvas : CanvasLayer
{
	[Export] protected ProgressBar lifeBar;
	public override void _Ready()
	{
		GameManager.player.OnDamaged += UpdateLifeBar;
		GameManager.player.OnHealed += UpdateLifeBar;
	}

	public void UpdateLifeBar(float newValue , float maxValue)
	{
		lifeBar.Value = (newValue / maxValue) ;

	}
}
