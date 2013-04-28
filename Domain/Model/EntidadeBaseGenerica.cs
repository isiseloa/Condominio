using System.Linq;
using System.Collections;
using NHibernate.Criterion;
using System.Collections.Generic;
using System;
using Domain.Util.Repository;

namespace Domain.Model
{
    /// <summary>
    /// Classe a ser herdada por todas as classes de regra de negócio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class EntidadeBase<T> : EntidadeBase where T : EntidadeBase
    {

        #region Metodos do Pattern Active Record

        public static IList FindAll()
        {
            return new RepositoryBase<T>().FindAll().ToList();
        }

        public static IList FindAll(ICriterion[] criteria)
        {
            return new RepositoryBase<T>().FindAll(criteria).ToList();
        }

        public static IList FindAll(Order[] orders, ICriterion[] criteria)
        {
            return new RepositoryBase<T>().FindAll(orders, criteria).ToList();
        }

        public static T FindByPrimaryKey(object id)
        {
            return new RepositoryBase<T>().FindByPrimaryKey(id);
        }

        public static T FindByPrimaryKey(object id, bool ErroQuandoNulo)
        {
            return new RepositoryBase<T>().FindByPrimaryKey(id, ErroQuandoNulo);
        }

        public static T FindFirst(params ICriterion[] criterios)
        {
            return new RepositoryBase<T>().FindFirst(criterios);
        }

        public static IList FindAllByProperty(string atributo, object valor)
        {
            return new RepositoryBase<T>().FindAllByProperty(atributo, valor);
        }

        public static IList FindAllByProperty(string ordenarPor, string atributo, object valor)
        {
            return new RepositoryBase<T>().FindAllByProperty(ordenarPor, atributo, valor);
        }

        public static IList SlicedFindAll(int firstResult, int maxResults, params ICriterion[] criterias)
        {
            return new RepositoryBase<T>().SlicedFindAll(firstResult, maxResults, criterias);
        }

        public static IList SlicedFindAll(int firstResult, int maxResults, Order[] orders, params ICriterion[] criterias)
        {
            return new RepositoryBase<T>().SlicedFindAll(firstResult, maxResults, orders, criterias);
        }

        public bool Exists()
        {
            return new RepositoryBase<T>().Exists();
        }

        public bool Exists(object Id)
        {
            return new RepositoryBase<T>().Exists(Id);
        }

        public bool Exists(ICriterion[] criteria)
        {
            return new RepositoryBase<T>().Exists(criteria);
        }

        public int Count()
        {
            return new RepositoryBase<T>().Count();
        }

        public int Count(ICriterion[] criteria)
        {
            return new RepositoryBase<T>().Count(criteria);
        }

        public static void DeleteAll()
        {
            new RepositoryBase<T>().DeleteAll();
        }

        public static void DeleteAll(IEnumerable ListaIds)
        {
            new RepositoryBase<T>().DeleteAll(ListaIds);
        }

        public static void Delete(int id)
        {
            var lista = new List<int>(1);
            lista.Add(id);
            new RepositoryBase<T>().DeleteAll(lista);
        }

        public void Refresh()
        {
            this.Repository.Refresh(this);
        }

        public static IOrderedQueryable<T> Todos
        {
            get { return RepositoryBase<T>.Todos; }
        }

        #endregion

    }
}
