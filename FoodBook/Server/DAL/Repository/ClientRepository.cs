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

    //TODO : V2 : Client et IClientRepository
    //Aucune requête Client n'a été implémenté sur cette version
    //Update 16/06/2021 : Client n'existe plus : Il a été remplacé par User

    class ClientRepository : IClientRepository
    {
        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> InsertAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
