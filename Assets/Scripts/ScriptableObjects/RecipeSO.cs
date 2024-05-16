using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject {
    [SerializeField] public List<KitchenObjectSO> kitchenObjectSOList;

    public string recipeName;
    
}
