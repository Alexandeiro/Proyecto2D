using UnityEngine;

public class RobotAnimatorController : MonoBehaviour
{


    [SerializeField] private Animator animator;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
    }
}
