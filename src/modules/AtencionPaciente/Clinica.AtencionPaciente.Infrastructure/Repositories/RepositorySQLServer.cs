using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Ports;
using Clinica.AtencionPaciente.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Infrastructure.Repositories
{
    public class RepositorySQLServer : IRepository
    {
        private readonly AtencionContext context;

        public RepositorySQLServer(AtencionContext context)
        {
            this.context = context;
        }

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            try
            {
                return context.Set<T>().AsQueryable().Any(expression);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo verificiar si existe la entidad {e.Message}");
            }
        }

        public async Task<T> Get<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<List<T>> GetAll<T>(Expression<Func<T, bool>> expression, 
            CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                return await context.Set<T>().Where(expression).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<T> GetFirst<T>(CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<T> Save<T>(T obj, CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                var entity = await context.Set<T>().AddAsync(obj, cancellationToken);

                //confirma que se añadio el objeto
                if (await context.SaveChangesAsync(cancellationToken) < 0)
                    throw new Exception($"no se guardo la entidad en la db: {obj.GetType()}");

                return entity.Entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        public async Task<T> Update<T>(T obj, CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                context.Entry(await context.Set<T>().FirstOrDefaultAsync(x => x.Id == obj.Id)).CurrentValues.SetValues(obj);

                if (await context.SaveChangesAsync(cancellationToken) < 0)
                    throw new Exception($"no se actualizo la entidad en la db: {obj.GetType()}");

                return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == obj.Id);
            }
            catch (Exception e)
            {
                throw new Exception($"no se pudo actualizr  la entidad {e.Message}");
            }
        }

        public async Task<List<T>> GetAll<T>(Expression<Func<T, bool>> expression, Expression<Func<T, double>> desendente,
            CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                return await context.Set<T>()
                    .Where(expression)
                    .OrderByDescending(desendente)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

    }
}
