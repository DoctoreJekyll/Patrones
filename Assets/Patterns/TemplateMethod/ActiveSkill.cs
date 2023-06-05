using UnityEngine;

namespace Patterns.TemplateMethod
{
    public abstract class ActiveSkill : ScriptableObject
    {
        [SerializeField] private float cooldownSeconds;
        private float currentCooldown;

        public bool IsReady()
        {
            return currentCooldown <= 0f;
        }

        public void Activate(Hero hero)
        {
            DoActivate(hero);
            SetCooldown();
        }

        private void SetCooldown()
        {
            currentCooldown = cooldownSeconds;
        }

        public void Update()
        {
            currentCooldown -= Time.deltaTime;
            currentCooldown = Mathf.Max(0, currentCooldown);
            DoUpdate();
        }

        protected abstract void DoUpdate();
        protected abstract void DoActivate(Hero heroTemp);
    }
}
