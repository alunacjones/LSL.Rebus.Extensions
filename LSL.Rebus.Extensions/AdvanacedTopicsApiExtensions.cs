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
            await topicsApi.Subscribe($"{typeof(T).GetSimpleAssemblyQualifiedName()}@{exchangeName}").ConfigureAwait(false);
    }
}