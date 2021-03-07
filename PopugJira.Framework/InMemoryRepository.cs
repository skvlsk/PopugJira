using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PopugJira.Framework
{
    internal class InMemoryRepository<TDocument, TKey> : IRepository<TDocument, TKey>
        where TDocument : class, IDocument<TKey>
    {
        private readonly ConcurrentDictionary<TKey, TDocument> _collection;

        public InMemoryRepository()
        {
            _collection = new ConcurrentDictionary<TKey, TDocument>();
        }
        
        public Task<TDocument> GetById(TKey id)
        {
            var result = _collection.TryGetValue(id, out var document) ? document : null;
            return Task.FromResult(result);
        }

        public Task<List<TDocument>> GetList(Expression<Func<TDocument, bool>> predicate)
        {
            var func = predicate.Compile();
            return Task.FromResult(_collection.Values.Where(x => func(x)).ToList());
        }

        public Task<TDocument> Insert(TDocument document)
        {
            _collection.TryAdd(document.Id, document);
            return Task.FromResult(document);
        }

        public Task<TDocument> Update(TDocument document)
        {
            _collection[document.Id] = document;
            return Task.FromResult(document);
        }
    }
}