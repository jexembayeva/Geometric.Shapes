using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Utils.Exceptions;
using Utils.Interfaces;

namespace Database
{
    public static class ContextExtensions
    {
        public static async Task<T> AddEntityAsync<T>(this DatabaseContext set, T entity)
            where T : class
        {
            var entry = await set.AddAsync(entity);
            return entry.Entity;
        }

        
        public static async Task<T> ByIdOrFailAsync<T>(this IQueryable<T> query, long id)
            where T : class, IHasId
        {
            return await query.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw ResourceNotFoundException.CreateFromEntity<T>(id);
        }

    }
}
