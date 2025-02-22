﻿using BO.Entity;
using DAL.Repository;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// All concern about restauration service
    /// </summary>
    internal class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _db;
        public RestaurantService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        #region Ingredients
        /// <summary>
        /// Create an ingredient !
        /// </summary>
        /// <param name="ingredient">Ingredients</param>
        /// <returns>Ingredients</returns>
        public async Task<Ingredients> CreateIngredient(Ingredients ingredient)
        {
            _db.BeginTransaction();
            IIngredientRepository _ingredient = _db.GetRepository<IIngredientRepository>();
            Ingredients newIngredient = await _ingredient.InsertAsync(ingredient);
            _db.Commit();
            return newIngredient;
        }
        /// <summary>
        /// Modify an ingredient
        /// </summary>
        /// <param name="ingredient">Ingredients</param>
        /// <returns>Ingredients</returns>
        public async Task<Ingredients> ModifyIngredient(Ingredients ingredient)
        {
            _db.BeginTransaction();
            IIngredientRepository _ingredients = _db.GetRepository<IIngredientRepository>();
            try
            {
                await _ingredients.UpdateAsync(ingredient);
                _db.Commit();
                return ingredient;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                _db.Rollback();
                return null;
            }
        }
        /// <summary>
        /// Remove one ingredient with its Id
        /// </summary>
        /// <param name="id">Int</param>
        /// <returns>bool</returns>
        public async Task<bool> RemoveIngredientById(int id)
        {
            _db.BeginTransaction();
            IIngredientRepository _ingredients = _db.GetRepository<IIngredientRepository>();
            try
            {
                var count = await _ingredients.DeleteAsync(id);
                _db.Commit();
                return count > 0;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                _db.Rollback();
                return false;
            }
        }
        /// <summary>
        /// Get all ingredients
        /// </summary>
        /// <returns>List of Ingredients ></returns>
        public async Task<List<Ingredients>> GetAllIngredients()
        {
            IIngredientRepository _ingredients = _db.GetRepository<IIngredientRepository>();

            List<Ingredients> ingredients = (await _ingredients.GetAllAsync()).ToList();

            return ingredients;
        }
        /// <summary>
        /// Get Ingredient By IF
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ingredients </returns>
        public async Task<Ingredients> GetIngredientById(int id)
        {

            IIngredientRepository _ingredient = _db.GetRepository<IIngredientRepository>();

            return await _ingredient.GetAsync(id);
        }
        #endregion

        #region Dish
        /// <summary>
        /// Get A list of all dishes on the FoodBook data base.
        /// </summary>
        /// <returns>A List of Dish</returns>
        public async Task<List<Dish>> GetAllDish()
        {
            IDishRepository _dish = _db.GetRepository<IDishRepository>();
            List<Dish> dishes = (await _dish.GetAllAsync()).ToList();
            return dishes;
        }
        public async Task<Dish> GetDishByName(string name)
        {
            IDishRepository _dish = _db.GetRepository<IDishRepository>();

            return await _dish.GetAsyncByName(name);
        }
        /// <summary>
        /// Get a Dish By an ID
        /// </summary>
        /// <param name="id">Identifiant unique du plat</param>
        /// <returns>Renvoi le plat si trouvé</returns>
        public async Task<Dish> GetDishById(int id)
        {

            IDishRepository _dish = _db.GetRepository<IDishRepository>();

            return await _dish.GetAsync(id);
        }
        /// <summary>
        /// Create a Dish
        /// </summary>
        /// <param name="dish">Dish</param>
        /// <returns>A new Dish</returns>
        public async Task<Dish> CreateDish(Dish dish)
        {
            _db.BeginTransaction();
            IDishRepository _dish = _db.GetRepository<IDishRepository>();
            Dish newDish = await _dish.InsertAsync(dish);
            _db.Commit();
            return newDish;
        }
        /// <summary>
        /// Modifier un plat
        /// </summary>
        /// <param name="dish">Dish</param>
        /// <returns>Un plat modifié</returns>
        public async Task<Dish> ModifyDish(Dish dish)
        {
            _db.BeginTransaction();
            IDishRepository _dish = _db.GetRepository<IDishRepository>();
            try
            {
                await _dish.UpdateAsync(dish);
                _db.Commit();
                return dish;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                _db.Rollback();
                return null;
            }
        }
        /// <summary>
        /// Supprimer un plat
        /// </summary>
        /// <param name="id">Int</param>
        /// <returns>Code No Content : 204</returns>
        public async Task<bool> RemoveDishById(int id)
        {
            _db.BeginTransaction();
            IDishRepository _dish = _db.GetRepository<IDishRepository>();
            try
            {
                var count = await _dish.DeleteAsync(id);
                _db.Commit();
                return count > 0;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                _db.Rollback();
                return false;
            }
        }
        public Task<Dish> GetIngredientsOfDishById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region TypeOfDish
        /// <summary>
        /// Get a list of TypeOfDish
        /// </summary>
        /// <returns></returns>
        public async Task<List<TypeOfDish>> GetAllTypeOfDish()
        {
            ITypeOfDishRepository _typeOfDish = _db.GetRepository<ITypeOfDishRepository>();
            List<TypeOfDish> typeOfDishes = (await _typeOfDish.GetAllAsync()).ToList();
            return typeOfDishes;
        }
        /// <summary>
        /// Get a TypeOfDish
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TypeOfDish> GetTypeOfDishById(int id)
        {
            ITypeOfDishRepository _dish = _db.GetRepository<ITypeOfDishRepository>();

            return await _dish.GetAsync(id);
        }
        #endregion
        
        #region Service

        public async Task<List<Service>> GetAllService()
        {
            IServiceRepository _service = _db.GetRepository<IServiceRepository>();
            List<Service> services = (await _service.GetServicesDetailsAsync()).ToList();
            return services;
        }

        public async Task<Service> GetServiceById(int id)
        {
            IServiceRepository _service = _db.GetRepository<IServiceRepository>();

            return await _service.GetAsync(id);
        }

        public async Task<IEnumerable<Service>> GetServiceByDate(DateTime date)
        {
            IServiceRepository _service = _db.GetRepository<IServiceRepository>();

            return await _service.GetServicesDetailsByDateAsync(date);
        }
        

        public async Task<Service> CreateService(Service service)
        {
            _db.BeginTransaction();
            IServiceRepository _service = _db.GetRepository<IServiceRepository>();
            Service newService = await _service.InsertAsync(service);
            _db.Commit();
            return newService;
        }

        /// <summary>
        /// Ajouter les plats au service !
        /// Méthode naîve, on supprime tout ce qui est ancien et on on recré la nouvelle.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task<bool> AddDishToService(Service service)
        {
            _db.BeginTransaction();
            IServiceRepository _service = _db.GetRepository<IServiceRepository>();

            //Supprimer les anciens en premier:
            //Seulement s'il y a déjà des anciens sinon il va renvoyer false !
            //var okUno = await _service.RemovAllIsComposedByIdService(service.Id);
            var okUno = true;
             
            //Ajouter les nouveaux ensuite.
            var okDeuse =await _service.AddDishToService(service);
            if (okUno && okDeuse)
            {
                okUno = true;
                _db.Commit();
            }
            else
            {
                okUno = false;
                _db.Rollback();
            }

            return okUno ;
        }


        public Task<bool> RemoveDishForThisService(Dish dish, Service service)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetServicesByIdMenu(int idMenu)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region ListOfDish

        public async Task<List<ListOfIngredient>> GetAllListOfIngredient()
        {
            IListOfIngredientRepository _listOfIngredient = _db.GetRepository<IListOfIngredientRepository>();
            List<ListOfIngredient> listOfIngredient = (await _listOfIngredient.GetAllAsync()).ToList();
            return listOfIngredient;
            
        }

        public Task<List<ListOfIngredient>> GetListOfIngredientByIdDish(int idDish)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Créer une ListOfIngredient
        /// </summary>
        /// <param name="listOfIngredient"></param>
        /// <returns></returns>
        public async Task<ListOfIngredient> CreateListOfIngredient(ListOfIngredient listOfIngredient)
        {

            _db.BeginTransaction();
            IListOfIngredientRepository _listOfIngredient = _db.GetRepository<IListOfIngredientRepository>();
            ListOfIngredient newListOfIngredient = await _listOfIngredient.InsertAsync(listOfIngredient);
            _db.Commit();
            return newListOfIngredient;
        }

        public Task<ListOfIngredient> ModifyListOfIngredient(ListOfIngredient listOfIngredient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveListOfIngredientById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
        
        #region Booking
        public async Task<Booking> CreateBooking(Booking booking)
        {
            _db.BeginTransaction();
            IBookingRepository _booking = _db.GetRepository<IBookingRepository>();
            Booking newBooking = await _booking.InsertAsync(booking);
            _db.Commit();
            return newBooking;
        }
        public async Task<Booking> GetBookingById(int id)
        {
            IBookingRepository _booking = _db.GetRepository<IBookingRepository>();
            return await _booking.GetAsync(id);
        }





        #endregion
        
        #region IsComposed
        public async Task<IsComposed> CreateIsComposed(IsComposed isComposed)
        {
            _db.BeginTransaction();
            IIsComposedRepository _isComposed = _db.GetRepository<IIsComposedRepository>();
            IsComposed newIsComposed = await _isComposed.InsertAsync(isComposed);
            _db.Commit();
            return newIsComposed;
        }
        //Delete All Is Composed for This Service
        public async Task<bool> RemovAllIsComposedByIdService(int id)
        {
            _db.BeginTransaction();
            IIsComposedRepository _isComposed = _db.GetRepository<IIsComposedRepository>();
            try
            {
                var count = await _isComposed.DeleteAsync(id);
                _db.Commit();
                return count > 0;
            }
            catch (Exception e)
            {
                _db.Rollback();
                return false;
            }
        }

        #endregion

    }
}
