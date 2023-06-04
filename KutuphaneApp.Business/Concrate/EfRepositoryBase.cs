﻿using KutuphaneApp.Business.Abstract;
using KutuphaneApp.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneApp.Business.Concrate
{
	public class EfRepositoryBase<TEntity, TContext> : IEFRepositoryBase<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
	{
		public TEntity Add(TEntity entity)
		{
			using (TContext context =new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
			return entity;
		}

		public void Delete(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public TEntity Get(Expression<Func<TEntity, bool>> filter)
		{
			using (var context = new TContext())
			{
				return context.Set<TEntity>().SingleOrDefault(filter);
			}
		}

		public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
		{
			using (var context = new TContext())
			{
				return filter == null
					? context.Set<TEntity>().ToList()
					: context.Set<TEntity>().Where(filter).ToList();
			}
		}

		public TEntity Update(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
			return entity;
		}
	}
}
