using Godot;
public interface IHittable
{
	public void Hitt(HittData data);

}

public interface Iknockbackable
{
	public void Knockback(Vector3 direction, float force);
}

public interface IDamagable
{
	public void ApplyDamage(float damage);
}