using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Catalog.API.Infra;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
           
        }
        
        // options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        // {
        //     Name = "Authorization",
        //     Type = SecuritySchemeType.ApiKey, Scheme = "Bearer",
        //     BearerFormat = "JWT", In = ParameterLocation.Header,
        //     Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
        // });
        //     
        // options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        // {
        //     {
        //         new OpenApiSecurityScheme()
        //         {
        //             Reference = new OpenApiReference(){Type = ReferenceType.SecurityScheme, Id = "Bearer"}
        //         },
        //         new string[]{}
        //     }
        // });
    }
    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = "API Title",
            Version = description.ApiVersion.ToString(),
            Description = "API Description."
        };
        return info;
    }
    
    
}