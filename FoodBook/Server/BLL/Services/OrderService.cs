﻿using BO.Entity;
using DAL.Repository;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IUnitOfWork _db;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
    }
}
