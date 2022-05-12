using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Originator : MonoBehaviour
{
    [SerializeField]
    private GameObject memento;

    [SerializeField]
    private Transform trsfParent;

    // ***** STATE *****
    private Transform trsfPACMAN;

    private List<Transform> trsFANTOMS;

    private void Start()
    {
        trsFANTOMS = new List<Transform>();

        for (int i = 0; i < FindObjectsOfType<Fantome>().Length; i++)
        {
            trsFANTOMS.Add(FindObjectsOfType<Fantome>()[i].transform);
        }

        trsfPACMAN = FindObjectOfType<PlayerController>().transform;
    }

    public Memento Save(float t)
    {
        var curMemento = Instantiate(memento, Vector3.zero, Quaternion.identity, trsfParent);
        curMemento.name = "Memento " + t;
        return curMemento.GetComponent<Memento>();
    }

    public void Restore(Memento memento)
    {
        trsfPACMAN.position = memento.GetState()[0];
        for (int i = 0; i < trsFANTOMS.Count; i++)
        {
            trsFANTOMS[i].position = memento.GetState()[i + 1];
        }
    }
}