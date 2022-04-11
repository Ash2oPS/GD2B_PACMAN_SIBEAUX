using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : State
{
    private Vector3 destination;

    public RandomPatrol(Character character) : base(character)
    {
    }

    public override void Tick()
    {
        //character.(destination);

        if (ReachedHome())
        {
            //character.SetState(new WanderState(character));
        }
    }

    public override void OnStateEnter()
    {
        character.GetComponent<Renderer>().material.color = Color.blue;
    }

    private bool ReachedHome()
    {
        return Vector3.Distance(character.transform.position, destination) < 0.5f;
    }
}