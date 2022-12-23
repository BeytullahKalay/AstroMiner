using AbstractClasses;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Rocks
{
    public class RockTypePicker : MonoBehaviour
    {
        [SerializeField][Range(0, 1)] private float emptyRockPickChance;
        [SerializeField][Range(0, 1)] private float blueRockPickChance;
        [SerializeField][Range(0, 1)] private float yellowRockPickChance;

        private Rock _selectedRockType;

        public Rock SelectRockType()
        {
            var randVal = Random.value;
        
            if (randVal < emptyRockPickChance)
            {
                // make rock empty
                return gameObject.AddComponent<EmptyRock>();
            }
            else if (randVal < blueRockPickChance)
            {
                // make rock blue
                return gameObject.AddComponent<BlueRockTile>();
            }
            else
            {
                // make rock yellow
                return gameObject.AddComponent<YellowRockTile>();
            }
        }
    }
}
