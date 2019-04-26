
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;

namespace EquipmentInventory.Services
{
    public static class MapperAsyncProvider
    {
        public static async Task<T> ProjectToAsync<TSource, T>(this IMapper mapper, Task<TSource> task)
        {
            //TODO add handling ArgumentException 
            if (task.Exception != null)
            {
               
                throw new ArgumentException("Data from repository is not available " );
            }
            
            var tcs2 = new TaskCompletionSource<T>();

            await task.ContinueWith(t => {  tcs2.TrySetResult(mapper.Map<T>(t.Result)); });

            return await tcs2.Task;

        }
        
        
       
    }
}