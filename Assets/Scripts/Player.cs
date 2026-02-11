using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{


	#region Fields
	[SerializeField] private Jetpack _jetpack;
	private Animator _anim;
	private float xVelocity;
    #endregion

    #region Unity Callbacks
    private void Awake()
	{
		_anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
		_anim.SetBool("Flying", _jetpack.Flying);

        transform.localScale = new Vector3(_jetpack.FacingDirection, 1, 1);

        bool isWalking = _jetpack.IsGrounded && Mathf.Abs(_jetpack.HorizontalVelocity) > 0.1f;
        _anim.SetBool("Walking", isWalking);
    }

    public void PlayHitAnimation()
    {
        _anim.SetTrigger("Hit");
    }
    #endregion
}
