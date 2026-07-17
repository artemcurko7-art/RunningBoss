using UnityEngine;

namespace Game.Scripts.Menu.Game.Ended.AnimalView
{
    public class HandlerChangingLayer
    {
        public void Handle(Animal.AnimalView animalView, string layer)
        {
            animalView.gameObject.layer = LayerMask.NameToLayer(layer);

            Renderer[] renderers = animalView.GetComponentsInChildren<Renderer>();

            foreach (var render in renderers)
                render.gameObject.layer = LayerMask.NameToLayer(layer);
        }
    }
}