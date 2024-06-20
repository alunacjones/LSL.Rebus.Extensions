using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rebus.Bus.Advanced;
using Rebus.Extensions;

namespace LSL.Rebus.Extensions
{
    /// <summary>
    /// AdvancedTopicsApiExtensions
    /// </summary>
    public static class AdvancedTopicsApiExtensions
    {
        /// <summary>
        /// Subscribe to the given type but on a different exchange to your default bus settings
        /// </summary>
        /// <param name="topicsApi"></param>
        /// <param name="exchangeName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task Subscribe<T>(this ITopicsApi topicsApi, string exchangeName) =>
            await topicsApi.Subscribe(exchangeName, new[] { typeof(T) }).ConfigureAwait(false);

        /// <summary>
        /// Subscribe to the given types but on a different exchange to your default bus settings
        /// </summary>
        /// <param name="topicsApi"></param>
        /// <param name="eventTypes"></param>
        /// <param name="exchangeName"></param>
        /// <returns></returns>
        public static async Task Subscribe(this ITopicsApi topicsApi, string exchangeName, IEnumerable<Type> eventTypes) 
        {
            foreach (var type in eventTypes)
            {
                await topicsApi.Subscribe($"{type.GetSimpleAssemblyQualifiedName()}@{exchangeName}").ConfigureAwait(false);            
            }
        }            
    }
}