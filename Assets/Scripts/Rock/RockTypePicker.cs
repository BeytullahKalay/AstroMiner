using UnityEngine;
using Random = UnityEngine.Random;

public class RockTypePicker : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float emptyRockPickChance;
    [SerializeField][Range(0, 1)] private float blueRockPickChance;
    [SerializeField][Range(0, 1)] private float yellowRockPickChance;
    
    private void Start()
    {
        var randVal = Random.value;
        if (randVal < emptyRockPickChance)
        {
            // make rock empty
            gameObject.AddComponent<EmptyRock>();
        }
        else if (randVal < blueRockPickChance)
        {
            // make rock blue
            gameObject.AddComponent<BlueRock>();
        }
        else
        {
            // make rock yellow
            gameObject.AddComponent<YellowRock>();
        }
    }


}
