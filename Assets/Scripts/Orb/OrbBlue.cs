using AbstractClasses;

namespace Orb
{
    public class OrbBlue : Collectible
    {
        protected override void Awake()
        {
            base.Awake();
            Type = OrbType.Blue;
        }
    }
}
