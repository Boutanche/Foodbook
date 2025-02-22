﻿                                                                                                                                                                                                             using API.Controllers;
using BLL.Services;
using BO.DTO.Requests;
using BO.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UnitTest.Services;
using Xunit;

namespace UnitTest
{
    /// <summary>
    /// Mise en place des tests unitaires sur Ingredients 
    /// </summary>
    public class IngredientControllerUnitTest
    {
        /// <summary>
        /// Test Unitaire sur Create un Ingredient
        /// </summary>
        [Fact]
        public async void TestCreateIngredient()
        {
            //Arange
            IRestaurantService restaurantService = new FakeRestaurantService();
            IngredientsController ingredientsController = new(restaurantService);
            Ingredients salt = new();
            {
                salt.Name = "Salt";
                salt.Price = 1.5m;
            }
            //Act
            var saltIngredientActionResult = await ingredientsController.CreateIngredient(salt);
            //Assert
            Assert.NotNull(saltIngredientActionResult);
        }
        /// <summary>
        /// Test unitaire sur Modifier un Ingrédient
        /// </summary>
        [Fact]
        public async void TestModifyIngredient()
        {
            //Arrange
            IRestaurantService restaurantService = new FakeRestaurantService();
            IngredientsController ingredientsController = new(restaurantService);
            
            Ingredients salt = new();
            {
                salt.Name = "Salt";
                salt.Price = 1.5m;
            }

            Ingredients salt2 = new ()

            {
                Id = 105,
                Name = "Salt",
                Price = 1.5m
            };
            Ingredients saltGood = new ()
            {
                Id = 1,
                Name = "Salt",
                Price = 1.5m
            };
            //Act
            var IngredientActionResult = await ingredientsController.ModifyIngredient(1, salt) as BadRequestResult;
            var IngredientActionResultNull = await ingredientsController.ModifyIngredient(1, null) as BadRequestResult;
            var IngredientActionResultNotFoundCase = await ingredientsController.ModifyIngredient(105, salt2) as NotFoundResult;
            var IngredientActionResultOkCase = await ingredientsController.ModifyIngredient(1, saltGood) as OkObjectResult;

            //Assert
            Assert.NotNull(IngredientActionResult);
            Assert.NotNull(IngredientActionResultNull);
            Assert.NotNull(IngredientActionResultNotFoundCase);
            Assert.NotNull(IngredientActionResultOkCase);

        }
        /// <summary>
        /// Test Unitaire sur Get All
        /// </summary>
        [Fact]
        public async void GetAll()
        {
            //Arrange
            IRestaurantService restaurantService = new FakeRestaurantService();
            IngredientsController ingredientController = new (restaurantService);



            //Act
            ActionResult<List<Ingredients>> IngredientsActionResult = await ingredientController.GetAll();
            //Assert
            Assert.NotNull(IngredientsActionResult);
        }

        /// <summary>
        /// Test Unitaire sur GetIngredientById
        /// </summary>
        [Fact]
        public async void TestGetIngredientById()
        {
            //Arrange
            IRestaurantService restaurantService = new FakeRestaurantService();
            IngredientsController ingredientsController = new(restaurantService);

            //Act
            //Test sur id = 1 
            OkObjectResult ingredientActionResult1 = await ingredientsController.GetIngredientById(1) as OkObjectResult;
            //Test sur Résultat n'existe pas :
            NotFoundResult notFoundingredientActionResult = await ingredientsController.GetIngredientById(9999) as NotFoundResult;


            //Assert
            Assert.NotNull(ingredientActionResult1);
            Assert.Equal(200, ingredientActionResult1.StatusCode);
            Assert.NotNull(notFoundingredientActionResult);
            Assert.Equal(404, notFoundingredientActionResult.StatusCode);
        }
        /// <summary>
        /// Test Suppression d'ingrdédient par identifiant
        /// </summary>
        [Fact]
        public async void TestRemoveIngredientById()
        {
            //Arrange
            IRestaurantService restaurantService = new FakeRestaurantService();
            IngredientsController ingredientsController = new(restaurantService);

            //Act
            var noContentExpected = await ingredientsController.DeleteIngredient(1) as NoContentResult;

            //Assert
            Assert.NotNull(noContentExpected);
            Assert.Equal(204, noContentExpected.StatusCode);

        }
    }
}
