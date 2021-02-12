﻿using System.Threading.Tasks;
using CoreLearning.DBLibrary.Common;
using CoreLearning.DBLibrary.Interfaces.Common;

namespace CoreLearning.Infrastructure.Data.Repositories.Common
{
    public abstract class BaseRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public BaseRepository(MessengerContext context)
        {
            this.context = context;
        }

        protected readonly MessengerContext context;

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}