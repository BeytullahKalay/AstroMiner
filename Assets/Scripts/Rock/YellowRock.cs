public class YellowRock : CollectibleRock
{
    public override void Start()
    {
        _type = RockType.Yellow;
        _tile = GameManager.Instance.GetTileSpriteHolder().GetYellowRockSprite();
        base.Start();
    }
}