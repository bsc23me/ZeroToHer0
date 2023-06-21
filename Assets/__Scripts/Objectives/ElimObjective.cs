using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElimType { NUMBER, CHILD, ALL };

public class ElimObjective : Objective
{

    [SerializeField] private int enemies = 0;
    [SerializeField] private ElimType type = ElimType.NUMBER;
    private int killed = 0;
    
    public override string Name { get { return $"Kill Enemies: {killed}/{enemies}"; } }

    // Start is called before the first frame update
    void Start()
    {
        SetupEnemies();
        killed = 0;
    }

    /// <summary>
    /// Sets which enemies are counted for the elimination objective
    /// </summary>
    private void SetupEnemies()
    {
        if (type == ElimType.CHILD)
        {
            enemies = transform.childCount;
            foreach (Enemy e in transform.GetComponentsInChildren<Enemy>())
                e.Attach(this); // attach this objective to the enemy subject
        }
        else if (type == ElimType.ALL)
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
            enemies = list.Length;
            foreach (GameObject o in list)
                o.GetComponent<Enemy>().Attach(this); // attach this objective to the enemy subject
        }
    }

    public override void Notify()
    {
        base.Notify();
        killed++;
        if (killed == enemies)
            Complete();
    }

}
