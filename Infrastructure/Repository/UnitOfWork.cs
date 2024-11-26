﻿using Domain.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //fields
        private readonly IdentityDbContext context;
        private Hashtable repositories;

        public UnitOfWork(IdentityDbContext context)
        {
            this.context = context;
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
        public async Task<bool> SaveChangesReturnBool()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose() 
        { 
            context.Dispose(); 
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories == null) repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var respoitoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);

                
            }

            return (IGenericRepository<TEntity>) repositories[type];
        }
    }
}
