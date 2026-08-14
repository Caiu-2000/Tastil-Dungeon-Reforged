using Godot;

namespace Movement
{
	[GlobalClass]
	public partial class MovementComponent : CharacterBody3D
	{
		[Export] protected float maxSpeed = 5f;
		protected  Godot.Vector2 DesiredDirection;
		protected float currentSpeed;

		public void move(Vector3 moveDirection)
		{
			if (maxSpeed <= 0f)
			{
				maxSpeed = 5f;
			}

		
			Velocity = ((Transform.Basis.X * moveDirection.X) + (Transform.Basis.Z * moveDirection.Z)).Normalized() * maxSpeed;
			MoveAndSlide();
		}
	}
}
