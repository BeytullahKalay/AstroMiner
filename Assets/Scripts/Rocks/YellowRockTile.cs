using AbstractClasses;
using SCOB.RockTypeHolder;

namespace Rocks
{
    public class YellowRockTile : CollectibleRockTile
    {
        public override void Start()
        {
            _type = RockType.Yellow;
            _tile = GameManager.Instance.GetTileSpriteHolder().GetYellowRockSprite();
            base.Start();
        }
    }
}