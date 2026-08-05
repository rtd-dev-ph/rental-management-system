using Microsoft.OpenApi; 
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RMS.Api.Filters;

public class FileUploadOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileParams = context.MethodInfo.GetParameters()
            .Where(p => p.ParameterType == typeof(IFormFile));

        if (!fileParams.Any()) return;

        operation.RequestBody = new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = JsonSchemaType.Object,
                        Properties = new Dictionary<string, IOpenApiSchema>
                        {
                            ["file"] = new OpenApiSchema
                            {
                                Type =  JsonSchemaType.String,
                                Format = "binary"
                            },
                            ["isCover"] = new OpenApiSchema
                            {
                                Type = JsonSchemaType.Boolean
                            }
                        }
                    }
                }
            }
        };
    }
}
 