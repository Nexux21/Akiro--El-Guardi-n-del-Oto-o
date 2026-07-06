using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public Transform Axetransform;
    private float lastHorizontal = 0f;
    private float lastVertical = -1f; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

   
        if (horizontal != 0 || vertical != 0)
        {
            
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Y", vertical);

           
            lastHorizontal = horizontal;
            lastVertical = vertical;
        }
        else
        {
            
            animator.SetFloat("X", lastHorizontal);
            animator.SetFloat("Y", lastVertical);
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (animator != null) animator.SetTrigger("OnAttack");

            Collider2D[] colisiones = Physics2D.OverlapCircleAll(Axetransform.position, 2f);

            foreach (Collider2D col in colisiones)
            {
                if (col.gameObject.CompareTag("Enemy"))
                {
                    
                }
            }
        }
    }
}