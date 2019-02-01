using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CraftRecipeDatabase : MonoBehaviour {

    public List<CraftRecipe> recipes = new List<CraftRecipe>();

    private ItemDatabase itemDatabase;

    void Awake()
    {
        itemDatabase = GetComponent<ItemDatabase>();
        BuildCraftRecipeDatabase();
    }

    public Item CheckRecipe(int[] recipe)
    {
        foreach(CraftRecipe craftRecipe in recipes)
        {
            if(craftRecipe.requiredItems.SequenceEqual(recipe)) // might want to change this to
                // if(craftRecipe.requiredItems.OrderBy(i => i).SequenceEqual(recipe.OrderBy(i => i)))
            {
                return itemDatabase.GetItem(craftRecipe.itemToCraft);
            }
        }
        return null;
    }

    public int[] ReturnItemRecipe(int id)
    {
        foreach(CraftRecipe craftRecipe in recipes)
        {
            if(craftRecipe.itemToCraft == id)
            {
                return craftRecipe.requiredItems;
            }
        }
        return null;
    }

    void BuildCraftRecipeDatabase()
    {
        recipes = new List<CraftRecipe>()
        {
            new CraftRecipe(4, 
            new int[]{
                0, 2, 0,
                0, 1, 0,
                0, 0, 0
            }),

            new CraftRecipe(5,
            new int[]{
                3, 1, 0,
                3, 0, 1,
                3, 1, 0
            }), 

            new CraftRecipe(6,
            new int[]
            {
                0, 2, 0,
                0, 1, 0,
                0, 1, 0
            }), 

            new CraftRecipe(7,
            new int[]
            {
                0, 2, 0,
                0, 2, 0,
                0, 1, 0
            }),

            new CraftRecipe(8,
            new int[]
            {
                0, 3, 3,
                0, 1, 0,
                0, 1, 0
            })


        };
    }
}
