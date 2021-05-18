using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Domain.Ports
{
    public interface IRepository
    {
        /// <summary>
        /// almacena el objeto en la db
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Task<T> Save<T>(T obj, CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// verificar si existe una entidad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity;

        /// <summary>
        /// obtener unicamente el primero
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> GetFirst<T>(CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// obtener objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Get<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// retorna todos los objetos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetAll<T>(Expression<Func<T, bool>> expression, 
            CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// actualiza el objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Update<T>(T obj, CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// trar una lista de objetos desendentemente segun los predicados.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="desendente"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetAll<T>(Expression<Func<T, bool>> expression, Expression<Func<T, double>> desendente,
            CancellationToken cancellationToken) where T : Entity;
    }
}
