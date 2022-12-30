using System.Collections.Generic;
using Structs;
using UnityEngine;

namespace SCOB.UISpriteDecider
{
    [CreateAssetMenu(fileName = "UISpriteHolder",menuName = "ScriptableObjects/UiSpriteHolder")]
    public class UISpriteHolder : ScriptableObject
    {
        public List<CostImage> CostImages = new List<CostImage>();
    }
}
