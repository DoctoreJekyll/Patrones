using UnityEngine;

namespace Patterns.TemplateMethod
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private ActiveSkill skill1;
        [SerializeField] private ActiveSkill skill2;

        [SerializeField] private float maxHealth;
        private float currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth / 2;
        }

        public void AddHealth(float healthToAdd)
        {
            currentHealth = Mathf.Clamp(currentHealth + healthToAdd, 0, maxHealth);
            Debug.Log($"Current health: {currentHealth}");
        }

        private void Update()
        {
            UpdateSkills();
            TryUseSkills();
        }

        private void UpdateSkills()
        {
            skill1.Update();
            skill2.Update();
        }

        private void TryUseSkills()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                TryUseSkill(skill1);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                TryUseSkill(skill2);
            }
        }

        private void TryUseSkill(ActiveSkill skill)
        {
            if (skill.IsReady())
            {
                skill.Activate(this);
            }
        }
    }
}
