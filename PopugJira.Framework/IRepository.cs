using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PopugJira.Framework
{
    public interface IRepository<TDocument, TKey> where TDocument : class, IDocument<TKey>
    {
        public Task<TDocument> GetById(TKey id);
        public Task<List<TDocument>> GetList(Expression<Func<TDocument, bool>> predicate);
        public Task<TDocument> Insert(TDocument document);
        public Task<TDocument> Update(TDocument document);
    }
}