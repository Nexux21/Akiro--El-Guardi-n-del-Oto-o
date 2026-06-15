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

    public enum CombatAction Action;
    {
      None,
      Attack,

    }
    void Start()
    {
        switch (Action)
        {


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
