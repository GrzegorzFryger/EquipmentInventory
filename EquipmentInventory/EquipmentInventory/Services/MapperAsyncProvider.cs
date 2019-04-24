
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace EquipmentInventory.Services
{
    public static class MapperAsyncProvider
    {
        public static  Task<T> ProjectToAsync<TSource, T>(this IMapper mapper, Task<TSource> task)
        {

            var tcs2 = new TaskCompletionSource<T>();

            if (task.Status == TaskStatus.Faulted)
            {
                throw new ArgumentException("Error ");
            }
            
            var projectionTask = Task.Run(() =>
            {
                var mapperResult = mapper.Map<T>(task.Result);
                if (mapperResult != null)
                {
                    
                    tcs2.TrySetResult(mapperResult);
                }
                else
                {
                    
                    tcs2.SetCanceled();
                }
                
                
            });

            return  tcs2.Task;


        }
    }
}