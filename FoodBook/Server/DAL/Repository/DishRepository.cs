﻿using BO.Entity;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DAL.Repository
{
    class DishRepository : IDishRepository
    {
        private readonly DbSession _session;

        public DishRepository(DbSession dbSession)
        {
            _session = dbSession;
        }
        public async Task<int> DeleteAsync(long id)
        {
            var stmt = @"delete from dishes where id_dish = @id";
            return await _session.Connection.ExecuteAsync(stmt, new { Id = id }, _session.Transaction);
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            var stmt = @"select * from dishes";
            return await _session.Connection.QueryAsync<Dish>(stmt, null, _session.Transaction);
        }

        public async Task<Dish> GetAsync(int id)
        {
            //Eviter l'injection sql avec des reqêtes paramétrées
            var stmt = @"select * from dishes where id_dish = @id";
            return await _session.Connection.QueryFirstOrDefaultAsync<Dish>(stmt, new { Id = id }, _session.Transaction);
        }

        public async Task<Dish> InsertAsync(Dish entity)
        {
            var stmt = @"insert into dishes(Name, Popularity) output INSERTED.id_dish
            values (@Name, @Popularity)";
            int i = await _session.Connection.QuerySingleAsync<int>(stmt, entity, _session.Transaction);
            return await GetAsync(i);
        }

        public async Task UpdateAsync(Dish entity)
        {
            var stmt = @"UPDATE  dishes SET Name = @Name, Popularity= @Popularity WHERE id_dish = @id";
            await _session.Connection.QueryAsync<Ingredients>(stmt, entity, _session.Transaction);
        }
    }
}
