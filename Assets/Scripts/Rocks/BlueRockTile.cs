
using AbstractClasses;
using SCOB.RockTypeHolder;

namespace Rocks
{
    public class BlueRockTile : CollectibleRockTile
    {
        public override void Start()
        {
            _type = RockType.Blue;
            _tile = GameManager.Instance.GetTileSpriteHolder().GetBlueRockSprite();
            base.Start();
        }
    }
}