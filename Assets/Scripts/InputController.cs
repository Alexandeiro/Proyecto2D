using UnityEngine;
using System;

public class InputController : MonoBehaviour
{


	#region Fields
	[SerializeField] private Jetpack _jetpack;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal
        float horizontal = Input.GetAxis("Horizontal");
        _jetpack.MoveHorizontal(horizontal);

        //Vertical Fly
        if (Input.GetAxis("Vertical") > 0)
			_jetpack.FlyUp();
		else
			_jetpack.StopFlying();

	}
	#endregion


}
