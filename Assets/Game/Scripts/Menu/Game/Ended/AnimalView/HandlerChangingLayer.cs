using UnityEngine;

public class HandlerChangingLayer 
{
    public void Handle(AnimalView animalView, string layer)
    {
        animalView.gameObject.layer = LayerMask.NameToLayer(layer);
        
        Renderer[] renderers = animalView.GetComponentsInChildren<Renderer>();
        
        foreach (var render in renderers)
            render.gameObject.layer = LayerMask.NameToLayer(layer);
    }
}