using UnityEngine;
using System;

public class Item : MonoBehaviour, IRecolectable
{
	#region Enums
	public enum ItemTypes
	{
		None,
		NoSe,
		ErrorCode,
		PositiveWords
	}
	#endregion

	#region Properties
	[field: SerializeField] public ItemTypes Type { get; set; }
	#endregion

	#region Fields
	[SerializeField] private GameObject _particles;
	#endregion

	#region Public Methods
	public virtual void Recolected()
	{
		Destroy(gameObject);
		CreateParticles();
	}

	public virtual void Destroyed()
	{
		Destroy(gameObject);
	}
	#endregion

	#region Private Methods
	private void CreateParticles()
	{
		Instantiate(_particles, transform.position, Quaternion.identity);
	}
	#endregion
}
