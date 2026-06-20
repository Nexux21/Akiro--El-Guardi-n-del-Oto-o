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

    }
    public CombatAction Action;
    void Start()
    {
      switch (Action)
        {
          
        }

    }

    void Update()
    {
        
    }
}
