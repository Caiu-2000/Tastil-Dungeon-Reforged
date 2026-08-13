using Godot;

namespace Movement
{
	[GlobalClass]
	public partial class MovementComponent : CharacterBody3D
	{
		[Export] protected float maxSpeed = 5f;
		protected float currentSpeed;

		public void move(Vector3 moveDirection)
		{
			if (maxSpeed <= 0f)
			{
				maxSpeed = 5f;
			}

			Velocity = moveDirection.Normalized() * maxSpeed;
			GD.Print("Velocity: " + Velocity);
			MoveAndSlide();
		}
	}
}
