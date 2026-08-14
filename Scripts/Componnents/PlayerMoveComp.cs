using Godot;

using Movement;


[GlobalClass]
public partial class PlayerMoveComp : MovementComponent
{
	InputComponent inputComponent;
	private float DeltaTime;
	[Export] private Marker3D CameraMount;
	[Export] private float CameraSensitivity = 0.1f;
	[Export] private float CameraMaxAngle = 80f;
	[Export] private float CameraMinAngle = -80f;

	

	public override void _Ready()
	{
		inputComponent = GetNode<InputComponent>("/root/InputComponent");
		inputComponent.OnMovePressed += HandleMovePressed;
		inputComponent.OnMouseMoved += HandleMouseMoved;
	}

	private void HandleMovePressed(Vector2 direction)
	{
		DesiredDirection = direction;
		Vector3 moveDirection = new Vector3(DesiredDirection.X, 0, DesiredDirection.Y);
		move(moveDirection);
	}

	private void HandleMouseMoved(Vector2 mouseMovement)
	{
		mouseMovement *= DeltaTime;
		RotateY(-mouseMovement.X * CameraSensitivity);
		Vector3 mountRotation = CameraMount.Rotation;
		mountRotation.X = Mathf.Clamp(mountRotation.X - mouseMovement.Y * CameraSensitivity, Mathf.DegToRad(CameraMinAngle), Mathf.DegToRad(CameraMaxAngle));
		CameraMount.Rotation = mountRotation;
	}

	public override void _Process(double delta)
	{
		DeltaTime = (float)delta;
	}
}
