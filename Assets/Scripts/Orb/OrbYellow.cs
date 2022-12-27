using AbstractClasses;

namespace Orb
{
    public class OrbYellow : Collectible
    {
        protected override void Awake()
        {
            base.Awake();
            Type = OrbType.Yellow;
        }
    }
}
