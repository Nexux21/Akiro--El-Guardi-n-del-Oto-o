using UnityEngine;

public class Switch : MonoBehaviour
{
    public enum EnemysType
    {
        None,
        agresivo,
        miedoso,
        arquero,
        cuerpoacuerpo,
    }
    public EnemysType Type;

    public enum CombatAction 
    {
      None,
      Attack,
      Shield,

    }

    public CombatAction Action;
    void Start()
    {
        switch (Action)
        {
            case CombatAction.None:
                Debug.Log("No action");
                break;
            case CombatAction.Attack:
                Debug.Log("Attack");
                break;
            case CombatAction.Shield:
                Debug.Log("Shield");
                break;



        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
