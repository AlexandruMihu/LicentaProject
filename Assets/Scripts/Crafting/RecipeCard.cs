using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCard:MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image recipeIcon;

    public Recipe recipeLoaded {  get; set; }

    public void InitRecipeCard(Recipe recipe)
    {
        recipeLoaded = recipe;
        recipeIcon.sprite = recipe.FinalItem.Icon;
    }

    public void ClickRecipe()
    {
        CraftingManager.Instance.ShowRecipe(recipeLoaded);
    }
}

