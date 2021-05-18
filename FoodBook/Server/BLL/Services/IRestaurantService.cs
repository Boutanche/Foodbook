﻿using BO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRestaurantService
    {
        #region ingredients

        /// <summary>
        /// Récupérer un ingrédient par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Ingredients> GetIngredientById(int id);
        /// <summary>
        /// Créer un ingrédient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        Task<Ingredients> CreateIngredient(Ingredients ingredient);
        /// <summary>
        /// Modifier un ingrédient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        Task<Ingredients> ModifyIngredient(Ingredients ingredient);
        /// <summary>
        /// Supprimer un ingrédient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveIngredientById(int id);
        /// <summary>
        /// Récupérer la liste de tous les ingrédients
        /// </summary>
        /// <returns></returns>
        Task<List<Ingredients>> GetAllIngredients();
        Task<Dish> GetDishById(int id);
        #endregion
        #region Dish
        /// <summary>
        /// Récupérer la liste de tous les plats
        /// </summary>
        /// <returns></returns>
        Task<List<Dish>> GetAllDish();
        #endregion
    }
}