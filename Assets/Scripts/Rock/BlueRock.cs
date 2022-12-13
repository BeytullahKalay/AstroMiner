
public class BlueRock : CollectibleRock
{
    public override void Start()
    {
        _type = RockType.Blue;
        _tile = GameManager.Instance.GetTileSpriteHolder().GetBlueRockSprite();
        base.Start();
    }
}