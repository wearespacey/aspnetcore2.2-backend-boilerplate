using System.Linq;

namespace DAL.Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> TakePage<T>(this IQueryable<T> query, int pageIndex = Constants.PAGE_INDEX, int pageSize = Constants.PAGE_SIZE)
        {
            return query.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}
