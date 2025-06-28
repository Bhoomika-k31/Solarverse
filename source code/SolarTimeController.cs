using UnityEngine;

public class SolarTimeController : MonoBehaviour
{
    public float timeMultiplier = 1f;

    private Orbit[] orbits;
    private SelfRotate[] rotations;

    void Start()
    {
        orbits = FindObjectsOfType<Orbit>();
        rotations = FindObjectsOfType<SelfRotate>();
    }

    void Update()
    {
        foreach (var orbit in orbits)
        {
            orbit.orbitSpeed *= timeMultiplier;
        }

        foreach (var rotate in rotations)
        {
            rotate.rotationSpeed *= timeMultiplier;
        }

        timeMultiplier = 1f;
    }

    public void SetTimeMultiplier(float newMultiplier)
    {
        timeMultiplier = newMultiplier;
    }
}
