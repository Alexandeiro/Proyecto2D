using UnityEngine;
using System;

public class ItemNose : Item
{

	const float NOSE_DAMAGE = -20;

	#region Unity Callbacks
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
			Destroyed();

		if (collision.gameObject.tag == "Player")
		{
			Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            Player player = collision.gameObject.GetComponent<Player>();
            jetpack.AddEnergy(NOSE_DAMAGE);
			player.PlayHitAnimation();
			Recolected();
		}
	}
	#endregion


}
