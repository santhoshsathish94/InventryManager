using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace InventryManager.API.Middleware
{
    /// <summary>
    /// The purpose of this class is purely for convinience.
    /// It adds default values to Swagger UI requests.
    /// </summary>
    public class SwaggerSchemaFilter : ISchemaFilter
    {
        /// <summary></summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
            {
                return;
            }

            foreach (var property in schema.Properties)
            {
                if (property.Value.Default != null && property.Value.Example == null)
                {
                    property.Value.Example = property.Value.Default;
                }
            }
        }
    }
}
