using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public Transform Axetransform;
    void Start()
    {
        animator.SetFloat("X", 0);
        animator.SetFloat("Y", 0);
    }


    void Update()
    {
       float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 MoveDir = new Vector2(horizontal, vertical);
        
        animator.SetFloat("X", MoveDir.x);
        animator.SetFloat("Y", MoveDir.y);

        if(Input.GetKeyDown(KeyCode.E))
            {
            animator.SetTrigger("OnAttack");

         Collider2D[] colisiones =  Physics2D.OverlapCircleAll(Axetransform.position, 2f);

            foreach(Collider2D col in  colisiones) 
            {
                if(col.gameObject.tag == "Enemy")
                {
                    //col.GetComponent<Enemy>().TakeDamage(4F);
                }
            }

        }
    }
}
