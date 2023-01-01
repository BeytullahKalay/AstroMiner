using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyLightSpriteController : MonoBehaviour
    {
        [SerializeField] private Light2D light2D;

        private readonly FieldInfo _lightCookieSprite =
            typeof(Light2D).GetField("m_LightCookieSprite", BindingFlags.NonPublic | BindingFlags.Instance);

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            light2D.lightType = Light2D.LightType.Sprite;
        }

        private void Update()
        {
            _lightCookieSprite.SetValue(light2D, _spriteRenderer.sprite);
        }
    }
}