﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeServer.Domain.SharedKernel.Repository
{
    public interface IRepository<TModel, UIdentifier>
    {

        #region synchronous

        ICollection<TModel> FindAll(Expression<Func<TModel, bool>> predicate);

        TModel Find(Expression<Func<TModel, bool>> predicate);

        ICollection<TModel> GetAll();

        TModel GetById(UIdentifier id);

        void Add(TModel entity);

        void Delete(TModel entity);

        void DeleteById(UIdentifier id);

        int SaveChanges();

        #endregion

        #region asynchronous

        Task AddAsync(TModel entity, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteByIdAsync(UIdentifier id, CancellationToken cancellationToken = default(CancellationToken));

        Task<ICollection<TModel>> FindAllAsync(Expression<Func<TModel, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TModel> FindAsync(Expression<Func<TModel, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<ICollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<TModel> GetByIdAsync(UIdentifier id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        #endregion
    }
}
