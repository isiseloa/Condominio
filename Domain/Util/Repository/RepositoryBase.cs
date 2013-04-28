using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;
using Castle.ActiveRecord.Framework;
using System.Collections;
using Domain.Model;

namespace Domain.Util.Repository
{
    /// <summary>
    /// Classe para acesso ao banco de dados - encapsula o framework NHibernate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepository<T> where T : EntidadeBase
    {
        
        #region CREATE-UPDATE-DELETE

        public void CreateAndFlush(T Entidade)
        {
            Entidade.dataCriacao = DateTime.Now;
            Entidade.dataAlteracao = DateTime.Now;
            ActiveRecordMediator<T>.CreateAndFlush(Entidade);           
     
        }

        public void Create(T Entidade)
        {
            Entidade.dataCriacao = DateTime.Now;
            Entidade.dataAlteracao = DateTime.Now;
            ActiveRecordMediator<T>.CreateAndFlush(Entidade);
        }

        public void Save(T Entidade)
        {
            Entidade.dataCriacao = DateTime.Now;
            Entidade.dataAlteracao = DateTime.Now;
            ActiveRecordMediator<T>.Save(Entidade);
        }

        public void SaveAndFlush(T Entidade)
        {
            Entidade.dataCriacao = DateTime.Now;
            Entidade.dataAlteracao = DateTime.Now;
            ActiveRecordMediator<T>.SaveAndFlush(Entidade);
        }

        public void Update(T Entidade)
        {
            Entidade.dataAlteracao = DateTime.Now;
            ActiveRecordMediator<T>.Update(Entidade);
        }

        public void UpdateAndFlush(T Entidade)
        {
            Entidade.dataAlteracao = DateTime.Now;
            ActiveRecordMediator<T>.UpdateAndFlush(Entidade);
        }

        public void Delete(T Entidade)
        {
            ActiveRecordMediator<T>.Delete(Entidade);
        }

        public void DeleteAndFlush(T Entidade)
        {
            ActiveRecordMediator<T>.DeleteAndFlush(Entidade);
        }

        public void DeleteAll(IEnumerable ListaIds)
        {
            ActiveRecordMediator<T>.DeleteAll(typeof(T), ListaIds);
        }

        public void DeleteAll()
        {
            ActiveRecordMediator<T>.DeleteAll();
        }

        public void Refresh(T Entidade)
        {
            ActiveRecordMediator<T>.Refresh(Entidade);
        }


        #endregion

        #region COUNT

        public int Count()
        {
            return ActiveRecordMediator<T>.Count();
        }

        public int Count(ICriterion[] criteria)
        {
           return  ActiveRecordMediator<T>.Count(criteria);
        }

        #endregion

        #region EXISTS

        public bool Exists()
        {
            return ActiveRecordMediator<T>.Exists();
        }

        public bool Exists(object Id)
        {
            return ActiveRecordMediator<T>.Exists(Id);
        }

        public bool Exists(ICriterion[] criteria)
        {
            return ActiveRecordMediator<T>.Exists(criteria);
        }

        #endregion

        #region FIND ALL

        public T[] FindAll()
        {
            return ActiveRecordMediator<T>.FindAll();
        }

        public T[] FindAll(ICriterion[] criteria)
        {
            return ActiveRecordMediator<T>.FindAll(criteria);
        }

        public T[] FindAll(Order[] orders, ICriterion[] criteria)
        {
            return ActiveRecordMediator<T>.FindAll(orders, criteria);
        }



        public Array FindAll(Type type)
        {
            return ActiveRecordMediator.FindAll(type);
        }

        public Array FindAll(Type type, ICriterion[] criteria)
        {
            return ActiveRecordMediator.FindAll(type, criteria);
        }

        public Array FindAll(Type type, Order[] orders, ICriterion[] criteria)
        {
            return ActiveRecordMediator.FindAll(type, orders, criteria);
        }



        #endregion

        #region FIND BY PRIMARY KEY

        public T FindByPrimaryKey(object id)
        {
            return ActiveRecordMediator<T>.FindByPrimaryKey(id);
        }

        public T FindByPrimaryKey(object id, bool ErroQuandoNulo)
        {
            return ActiveRecordMediator<T>.FindByPrimaryKey(id, ErroQuandoNulo);
        }

        #endregion

        #region FIND FIRST

        public T FindFirst(params ICriterion[] criterios)
        {
            return ActiveRecordMediator<T>.FindFirst(criterios);
        }


        #endregion

        #region FIND ALL BY PROPERTY

        public T[] FindAllByProperty(string atributo, object valor)
        {
            return ActiveRecordMediator<T>.FindAllByProperty(atributo, valor);
        }

        public T[] FindAllByProperty(string ordenarPor, string atributo, object valor)
        {
            return ActiveRecordMediator<T>.FindAllByProperty(ordenarPor, atributo, valor);
        }

        #endregion

        public T[] SlicedFindAll(int firstResult, int maxResults, params ICriterion[] criterias)
        {
            return ActiveRecordMediator<T>.SlicedFindAll(firstResult, maxResults, criterias);
        }

        public T[] SlicedFindAll(int firstResult, int maxResults, Order[] orders, params ICriterion[] criterias)
        {
            return ActiveRecordMediator<T>.SlicedFindAll(firstResult, maxResults, orders, criterias);
        }



        public static IOrderedQueryable<T> Todos
        {
            get
            {
                return ActiveRecordLinq.AsQueryable<T>();
            }
        }





       
    }
}


