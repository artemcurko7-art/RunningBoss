using UnityEngine;

namespace Game.Scripts.Inventory.ItemContext
{
    public class Item
    {
        private float _degreeOfOccupancy;

        public float DegreeOfOccupancy
        {
            get => _degreeOfOccupancy;

            private set => _degreeOfOccupancy = Mathf.Clamp01(value);
        }

        public void AddDegreeOfOccupancy(float amount)
        {
            DegreeOfOccupancy += amount;
        }
    }
}