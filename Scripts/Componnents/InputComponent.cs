using Godot;
using System;

public partial class InputComponent : Node
{
	public delegate void MovePressedEventHandler(Vector2 direction);
	public delegate void MouseMovedEventHandler(Vector2 MouseMovement);
	public MovePressedEventHandler OnMovePressed = delegate { };
	public MouseMovedEventHandler OnMouseMoved = delegate { };



	public override void _Ready()
	{
		_ToggleMouse(true);
	}
	public override void _Process(double delta)
	{

	}
    public override void _PhysicsProcess(double delta)
    {
		base._PhysicsProcess(delta);
       	Vector2 direction = new Vector2();

		direction = Input.GetVector("Left", "Right", "Foward", "Backwards");
		OnMovePressed?.Invoke(direction);
    }

	public override void _UnhandledInput(InputEvent @event)
	{
		
		if (@event is InputEventMouseMotion mouseMotion)
		{
		   OnMouseMoved?.Invoke(mouseMotion.Relative);
		}
	}
	public void _ToggleMouse(bool toggle)
	{
		Input.MouseMode = toggle ? Input.MouseModeEnum.Captured : Input.MouseModeEnum.Visible;
	}
}
