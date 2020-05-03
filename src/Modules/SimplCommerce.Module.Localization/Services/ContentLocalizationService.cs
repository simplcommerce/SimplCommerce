using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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
                localizedProperties = GetLocalizedPropertiesFromDb(entityType, entityId, cultureId);

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

        public Func<long, string, string, string> GetLocalizationFunction<TEntity>()
        {
            return GetLocalizationFunction(typeof(TEntity).Name);
        }

        public Func<long, string, string, string> GetLocalizationFunction(string entityType)
        {
            var localizedContentProperties = GetLocalizationFromDb(entityType);

            Func<long, string, string, string> resultFunction = (long entityId, string propertyName, string propertyValue) =>
            {
                if (!localizedContentProperties.Any())
                {
                    return propertyValue;
                }

                var result = localizedContentProperties.Where(lcp => lcp.EntityId == entityId && lcp.ProperyName == propertyName);

                return result.FirstOrDefault()?.Value ?? propertyValue;
            };

            return resultFunction;
        }

        private List<LocalizedContentProperty> GetLocalizationFromDb(string entityType)
        {
            return GetLocalizationFromDb(entityType, CultureInfo.CurrentCulture.Name);
        }

        private List<LocalizedContentProperty> GetLocalizationFromDb(string entityType, string cultureId)
        {
            if (!_isLocalizedConentEnable)
            {
                return new List<LocalizedContentProperty>();
            }

            var localizedProperties = GetLocalizedPropertiesFromDb(entityType, null, cultureId);

            return localizedProperties;
        }

        private List<LocalizedContentProperty> GetLocalizedPropertiesFromDb(string entityType, long? entityId, string cultureId)
        {
            Expression<Func<LocalizedContentProperty, bool>> expression = localizedContentProperty => entityId == null
                ? localizedContentProperty.EntityType == entityType
                    && localizedContentProperty.CultureId == cultureId
                : localizedContentProperty.EntityId == entityId
                    && localizedContentProperty.EntityType == entityType
                    && localizedContentProperty.CultureId == cultureId;

            var localizedProperties = _entityRepository.Query().Where(expression).ToList();
            return localizedProperties;
        }
    }

    //internal static class SqlExtensions // EF 3.1
    //{
    //    public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
    //    {
    //        var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression).GetEnumerator();
    //        var relationalCommandCache = enumerator.Private("_relationalCommandCache");
    //        var selectExpression = relationalCommandCache.Private<SelectExpression>("_selectExpression");
    //        var factory = relationalCommandCache.Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

    //        var sqlGenerator = factory.Create();
    //        var command = sqlGenerator.GetCommand(selectExpression);

    //        string sql = command.CommandText;
    //        return sql;
    //    }

    //    private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
    //    private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
    //}
}
