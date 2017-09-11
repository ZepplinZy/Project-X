using UnityEngine;

public class Health : MonoBehaviour
{

    public int currentHP;
    public int HP = 500;

    public bool IsAlive { get { return currentHP > 0; } }

    void Start()
    {
        currentHP = HP;
    }

    void Update()
    {
        if (!IsAlive)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int dmg)
    {
        //Debug.Log("cp" + currentHP);
        currentHP += dmg < currentHP ? -dmg : -currentHP;
        Debug.Log(gameObject.name);
        //Debug.Log("cpcp" + currentHP);

    }

    


}
