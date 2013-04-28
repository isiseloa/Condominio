using System.Linq;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections;
using NHibernate.Criterion;
using Domain.Util.Repository;

namespace Domain.Model
{
    /// <summary>
    /// classe a ser herdada por todas as classes de regra de negócio
    /// </summary>
    [Serializable]
    public class EntidadeBase
    {

        private IRepository<EntidadeBase> repository;

        /// <summary>
        /// objeto de acesso ao banco de dados
        /// </summary>
        protected IRepository<EntidadeBase> Repository
        {
            get
            {
                if (repository == null)
                    repository = new RepositoryBase<EntidadeBase>();
                return repository;
            }
        }

        [PrimaryKey(Generator = PrimaryKeyType.Native, Column = "ID")]
        public int Id { get; set; }

        [Property("DataCriacao", Update = false, NotNull = true)]
        internal DateTime dataCriacao { get; set; }

        [Property("DataAlteracao", NotNull = true)]
        internal DateTime dataAlteracao { get; set; }       

       
        /// <summary>
        /// promove a leitura da data de criação, impedindo sua alteração
        /// </summary>
        public DateTime DataCriacao
        {
            get { return dataCriacao; }
        }

        /// <summary>
        ///  promove a leitura da data de alteração, impedindo sua alteração
        /// </summary>
        public DateTime DataAlteracao
        {
            get { return dataAlteracao; }
        }




        #region Metodos do Pattern ActiveRecord

        public void Create()
        {
            Repository.Create(this);
        }

        public void CreateAndFlush()
        {
            Repository.CreateAndFlush(this);
        }

        public void Delete()
        {
            Repository.Delete(this);
        }

        public void DeleteAndFlush()
        {
            Repository.DeleteAndFlush(this);
        }

        public void Update()
        {
            Repository.Update(this);
        }

        public void UpdateAndFlush()
        {
            Repository.UpdateAndFlush(this);
        }


        public void Save()
        {
            Repository.Save(this);
        }

        public void SaveAndFlush()
        {
            Repository.SaveAndFlush(this);
        }


        public static IList FindAll(Type type)
        {
            return new RepositoryBase<EntidadeBase>().FindAll(type);
        }

        public static IList FindAll(Type type, ICriterion[] criteria)
        {
            return new RepositoryBase<EntidadeBase>().FindAll(type, criteria);
        }

        public static IList FindAll(Type type, Order[] orders, ICriterion[] criteria)
        {
            return new RepositoryBase<EntidadeBase>().FindAll(type, orders, criteria);
        }



        #endregion
    }
}
