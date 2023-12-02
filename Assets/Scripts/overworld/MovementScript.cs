using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public LayerMask interactableLayer;

    private bool isMoving;
    private Vector3 input;
    private Animator animator;

    public bool inBattle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        inBattle = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Controls switch between idle and walk
        if (input != Vector3.zero)
        {
            // walk animation
            isMoving = true;
            animator.SetFloat("moveY", input.y);
            animator.SetFloat("moveX", input.x);
        }
        else
        {
            // turns to idle animation and holds the direction before you stopped
            isMoving = false;
        }
 

        if ((Vector3.Distance(transform.position, movePoint.position) <= .05f) & (inBattle == false))
        {
            if (Mathf.Abs(input.x) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(input.x, 0f, 0f), .3f, whatStopsMovement | interactableLayer))
                {
                    movePoint.position += new Vector3(input.x, 0f, 0f);
                }
            }
            else if (Mathf.Abs(input.y) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, input.y, 0f), .3f, whatStopsMovement | interactableLayer))
                {
                    movePoint.position += new Vector3(0f, input.y, 0f);
                }
            }
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }


    }
}
