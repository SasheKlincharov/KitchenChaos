using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject {


    public KitchenObjectSO inputSO;
    public KitchenObjectSO outputSO;
    public float burningTimeMax;
}
 