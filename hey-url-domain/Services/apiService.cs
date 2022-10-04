using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HeyUrlDomain.Data;
using HeyUrlDomain.Services;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Services;

namespace hey_url_domain.Services
{
    public class ApiService : IResourceService<UrlModel, Guid>
    {
        private  readonly IUrlRepository _repository;
        public ApiService(IUrlRepository repository )
        {
            _repository=repository;
        }
        public async Task<UrlModel> CreateAsync(UrlModel resource, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AddToToManyRelationshipAsync(Guid primaryId, string relationshipName, ISet<IIdentifiable> secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UrlModel> UpdateAsync(Guid id, UrlModel resource, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SetRelationshipAsync(Guid primaryId, string relationshipName, object secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromToManyRelationshipAsync(Guid primaryId, string relationshipName, ISet<IIdentifiable> secondaryResourceIds,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<UrlModel>> GetAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            return result.Select(s => new UrlModel()
            {
                LongUrl = s.LongUrl,
                Count = s.Count,
                CreateDateTime = s.CreateDateTime,
                Id = s.Id,
                ShortUrl = s.ShortUrl
            }).ToList();
        }

        public async Task<UrlModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetRelationshipAsync(Guid id, string relationshipName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetSecondaryAsync(Guid id, string relationshipName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
