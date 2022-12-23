using AbstractClasses;

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