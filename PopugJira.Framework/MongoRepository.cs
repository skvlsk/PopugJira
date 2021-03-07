using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace PopugJira.Framework
{
    internal class MongoRepository<TDocument, TKey> : IRepository<TDocument, TKey>
        where TDocument : class, IDocument<TKey>
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository()
        {
            
        }

        public async Task<TDocument> GetById(TKey id)
        {
            return await _collection.Find(Builders<TDocument>.Filter.Eq(x => x.Id, id)).FirstOrDefaultAsync();
        }

        public async Task<List<TDocument>> GetList(Expression<Func<TDocument, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public Task<TDocument> Insert(TDocument document)
        {
            if (document is null)
            {
                throw new ArgumentException(null, nameof(document));
            }

            if (document.AuditInfo is null)
            {
                var dateNow = DateTime.UtcNow;
                document.AuditInfo = new AuditInfo
                {
                    Version = 0,
                    CreatedAt = dateNow,
                    CreatedBy = "somebody",
                    UpdatedAt = dateNow,
                    UpdatedBy = "somebody"
                };
            }

            throw new NotImplementedException();
        }

        public Task<TDocument> Update(TDocument document)
        {
            throw new NotImplementedException();
        }
    }
}