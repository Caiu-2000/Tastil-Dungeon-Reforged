using Godot;

[GlobalClass]
public partial class Entity : Node
{
	[Export] protected float MaxLife = 50;
	protected float currentLife = 1; 





	[Signal]
	public delegate void HealtchangedEventHandler(float newValue);

  
	public HealtchangedEventHandler OnDamaged = delegate { };
	public HealtchangedEventHandler OnHealed  = delegate { };

	


}
