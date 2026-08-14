using Godot;
using System;

public partial class CameraController : Camera3D
{
	[Export] private bool FollowPlayer = true;

	[Export] private Marker3D ObjectiveNode; 
	[Export] public float PositionDampening = 10.0f;
    [Export] public float RotationDampening = 8.0f;
	public override void _Ready()
	{
		if (FollowPlayer)
		{
			Player player = GameManager.player;
			ObjectiveNode = player != null ? player.CamMount : null;
		}
	}
	

	 public override void _PhysicsProcess(double delta)
    {
        if (ObjectiveNode == null) return;

        float deltaTime = (float)delta;

      
        Vector3 currentPos = GlobalPosition;
        Vector3 targetPos = ObjectiveNode.GlobalPosition;
        GlobalPosition = currentPos.Lerp(targetPos, PositionDampening * deltaTime);

       
        Transform3D currentTransform = GlobalTransform;
        Transform3D targetTransform = ObjectiveNode.GlobalTransform;

        Quaternion currentQuat = currentTransform.Basis.GetRotationQuaternion();
        Quaternion targetQuat = targetTransform.Basis.GetRotationQuaternion();
        
        Quaternion smoothlyBlendedQuat = currentQuat.Slerp(targetQuat, RotationDampening * deltaTime);

        GlobalTransform = new Transform3D(new Basis(smoothlyBlendedQuat), GlobalPosition);
    }
}
