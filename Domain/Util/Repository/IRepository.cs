using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using System.Collections;
using Domain.Model;

namespace Domain.Util.Repository
{
    /// <summary>
    /// Interface genérica para o objeto de acesso ao banco de dados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : EntidadeBase
    {
        void Create(T Entidade);

        void CreateAndFlush(T Entidade);

        void Update(T Entidade);

        void UpdateAndFlush(T Entidade);

        void Delete(T Entidade);

        void DeleteAndFlush(T Entidade);

        int Count();

        int Count(ICriterion[] criteria);

        bool Exists();

        bool Exists(object Id);

        bool Exists(ICriterion[] criteria);

        T[] FindAll();

        T[] FindAll(ICriterion[] criteria);

        T[] FindAll(Order[] orders, ICriterion[] criteria);

        Array FindAll(Type type);    

        Array FindAll(Type type, ICriterion[] criteria);

        Array FindAll(Type type, Order[] orders, ICriterion[] criteria);

        void DeleteAll(IEnumerable ListaIds);

        void DeleteAll();

        T FindFirst(params ICriterion[] criterios);

        T[] FindAllByProperty(string ordenarPor, string atributo, object valor);

        T[] FindAllByProperty(string atributo, object valor);


        void Save(T Entidade);

        void SaveAndFlush(T Entidade);

        void Refresh(T Entidade);
    }
}
