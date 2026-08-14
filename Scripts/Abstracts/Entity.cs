using Godot;

[GlobalClass]
public partial class Entity : Node , IDamagable
{
	[Export] protected float MaxLife = 50;
	protected float currentLife = 1; 





	[Signal]
	public delegate void HealtchangedEventHandler(float newValue);
	public delegate void DiedEventHandler();
  
	public HealtchangedEventHandler OnDamaged = delegate { };
	public HealtchangedEventHandler OnHealed  = delegate { };
	public DiedEventHandler OnDied = delegate { };
	
	public override void _Ready()
	{
		currentLife = MaxLife;
	}

	public virtual void ApplyDamage(float damage)
	{
		currentLife -= damage;
		OnDamaged?.Invoke(currentLife);
		
		if (currentLife <= 0)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		OnDied?.Invoke();
		QueueFree();
	}

}
