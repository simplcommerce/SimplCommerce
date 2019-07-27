using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Localization.Services
{
    public class ContentLocalizationService : IContentLocalizationService
    {
        private readonly IRepository<LocalizedContentProperty> _entityRepository;
        private readonly bool _isLocalizedConentEnable;
        private IMemoryCache _memoryCache;

        public ContentLocalizationService(IRepository<LocalizedContentProperty> entityRepository, IMemoryCache memoryCache, IConfiguration config)
        {
            _entityRepository = entityRepository;
            _memoryCache = memoryCache;
            _isLocalizedConentEnable = config.GetValue<bool>("Localization.LocalizedConentEnable");
        }

        public string GetLocalizedProperty<TEntity>(TEntity entity, string propertyName, string propertyValue) where TEntity : EntityBase
        {
            var culture = CultureInfo.CurrentCulture.Name;
            return GetLocalizedProperty(entity, propertyName, propertyValue, culture);
        }

        public string GetLocalizedProperty<TEntity>(TEntity entity, string propertyName, string propertyValue, string cultureId) where TEntity : EntityBase
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return GetLocalizedProperty(entity.GetType().Name, entity.Id, propertyName, propertyValue, cultureId);
        }

        public string GetLocalizedProperty(string entityType, long entityId, string propertyName, string propertyValue)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            return GetLocalizedProperty(entityType, entityId, propertyName, propertyValue, culture);
        }

        public string GetLocalizedProperty(string entityType, long entityId, string propertyName, string propertyValue, string cultureId)
        {
            if (!_isLocalizedConentEnable)
            {
                return propertyValue;
            }

            var localizedProperties = new List<LocalizedContentProperty>();
            var cacheKey = $"{entityType}-{entityId}-{cultureId}";

            if (!_memoryCache.TryGetValue(cacheKey, out localizedProperties))
            {
                localizedProperties = _entityRepository.Query().Where(x => x.EntityId == entityId
                    && x.EntityType == entityType
                    && x.CultureId == cultureId).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

                _memoryCache.Set(cacheKey, localizedProperties, cacheEntryOptions);
            }

            var localizedProperty = localizedProperties.FirstOrDefault(x => x.ProperyName == propertyName);
            if (localizedProperty != null)
            {
                return localizedProperty.Value;
            }

            return propertyValue;
        }
    }
}
