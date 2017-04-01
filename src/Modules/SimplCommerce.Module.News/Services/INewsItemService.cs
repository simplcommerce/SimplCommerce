using SimplCommerce.Module.News.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.News.Services
{
    public interface INewsItemService
    {
        void Create(NewsItem newsItem);

        void Update(NewsItem newsItem);

        void Delete(long id);

        void Delete(NewsItem newsItem);
    }
}
