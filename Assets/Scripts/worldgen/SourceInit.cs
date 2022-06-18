using UnityEngine;
using Random = System.Random;

public class SourceInit : MonoBehaviour, MapInitializer
{
    [SerializeField] private GameObject sourceTemplate;
    [SerializeField] private Vector3 sourceRandomOffset;
    [SerializeField] private Vector3 sourceStaticOffset;

    public void Initialize()
    {
        var random = new Random();
        var randomOffset = random.Next() % 2 == 0 ? sourceRandomOffset : -sourceRandomOffset;
        var newSource = Instantiate(sourceTemplate, transform);
        newSource.transform.localPosition = randomOffset + sourceStaticOffset;
        newSource.GetComponent<Source>().Initialize(-randomOffset.normalized);
    }
}