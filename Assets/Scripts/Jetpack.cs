using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
	public enum Direction
	{
		Left,
		Right
	}

	#region Properties
	public float Energy 
	{
		get
		{
			return _energy;
		}
		set
		{
			_energy = Mathf.Clamp(value,0,_maxEnergy);
		}
	}
	public bool Flying { get; set; }

    public int FacingDirection { get; private set; } = 1;
    public bool IsGrounded { get; private set; }

    public float HorizontalVelocity => _targetRB.linearVelocity.x;
    #endregion

    #region Fields							     
    private Rigidbody2D _targetRB;
	[SerializeField] private float _energy;
	[SerializeField] private float _maxEnergy;
	[SerializeField] private float _energyFlyingRatio;
	[SerializeField] private float _energyRegenerationRatio;
	[SerializeField] private float _horizontalForce;
	[SerializeField] private float _flyForce;

    [SerializeField] private float _groundSpeed = 6f;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;


    #endregion

    #region Unity Callbacks
    private void Awake()
	{
		_targetRB = GetComponent<Rigidbody2D>();
	}
	// Start is called before the first frame update
	void Start()
	{
		Energy = _maxEnergy;
	}

	// Update is called once per physic frame
	void FixedUpdate()
	{
        CheckGround();

        if (Flying)
			DoFly();

        if (IsGrounded && !Flying)
            Regenerate();
    }

	#endregion

	#region Public Methods
	public void FlyUp()
	{
		Flying = true;
	}
	public void StopFlying()
	{
		Flying = false;
	}

    private void CheckGround()
    {
        IsGrounded = Physics2D.OverlapCircle(
            _groundCheck.position,
            _groundCheckRadius,
            _groundLayer
        );
    }

    public void Regenerate()
	{		
		Energy += _energyRegenerationRatio;
	}

	public void AddEnergy(float energy)
	{
		Energy += energy;
	}


    public void MoveHorizontal(float input)
    {
        if (input > 0.01f)
            FacingDirection = 1;
        else if (input < -0.01f)
            FacingDirection = -1;

        if (IsGrounded && !Flying)
        {
            _targetRB.linearVelocity = new Vector2(
                input * _groundSpeed,
                _targetRB.linearVelocity.y
            );
        }
        else
        {
            _targetRB.AddForce(Vector2.right * input * _horizontalForce);
        }
    }
    #endregion

    #region Private Methods
    private void DoFly()
	{
		if (Energy > 0)
		{
			_targetRB.AddForce(Vector2.up * _flyForce);
			Energy -= _energyFlyingRatio;
		}
		else
			Flying = false;
	}
	#endregion
}


