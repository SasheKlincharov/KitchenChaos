using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;  
    
    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // There is no kitchen object placed here
            if (player.HasKitchenObject()) {
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                // Player doesn't hold anything
            }
        } else {
            // There is Kitchen Object
            if (player.HasKitchenObject()) {
                // Player is carrying something

                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    // Player is holding a plate
                    bool ingredientSuccessfullyAdded = plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO());
                    if (ingredientSuccessfullyAdded) {
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        // Counter is holding a plate
                        bool ingredientSuccessfullyAdded = plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO());
                        if (ingredientSuccessfullyAdded) {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }

            } else {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
