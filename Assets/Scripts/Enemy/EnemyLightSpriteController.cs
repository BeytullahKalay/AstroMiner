using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Enemy
{
    public class EnemyLightSpriteController : MonoBehaviour
    {
        private Light2D _light2D;

        private readonly FieldInfo _lightCookieSprite =
            typeof(Light2D).GetField("m_LightCookieSprite", BindingFlags.NonPublic | BindingFlags.Instance);

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponentInParent<SpriteRenderer>();
            _light2D = GetComponent<Light2D>();
        }

        private void Update()
        {
            _lightCookieSprite.SetValue(_light2D, _spriteRenderer.sprite);
        }
    }
}