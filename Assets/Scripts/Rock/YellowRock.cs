
public class YellowRock : CollectibleRock
{
    public override void Start()
    {
        _type = RockType.Yellow;
        base.Start();
    }
}