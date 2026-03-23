using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Configuration;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Agregar YARP Reverse Proxy
builder.Services.AddReverseProxy()
    .LoadFromMemory(
        new[]
        {
            // Rutas del Gateway
            new RouteConfig
            {
                RouteId = "productRoute",
                ClusterId = "productCluster",
                Match = new RouteMatch { Path = "/api/products/{**catch-all}" }
            },
            new RouteConfig
            {
                RouteId = "customerRoute",
                ClusterId = "customerCluster",
                Match = new RouteMatch { Path = "/api/customers/{**catch-all}" }
            },
            new RouteConfig
            {
                RouteId = "orderRoute",
                ClusterId = "orderCluster",
                Match = new RouteMatch { Path = "/api/orders/{**catch-all}" }
            }
        },
        new[]
        {
            // Clusters / Destinos (CORREGIDO A 8080)
            new ClusterConfig
            {
                ClusterId = "productCluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    { "destination1", new DestinationConfig { Address = "http://productservice:8080/" } }
                }
            },
            new ClusterConfig
            {
                ClusterId = "customerCluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    { "destination1", new DestinationConfig { Address = "http://customerservice:8080/" } }
                }
            },
            new ClusterConfig
            {
                ClusterId = "orderCluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    { "destination1", new DestinationConfig { Address = "http://orderservice:8080/" } }
                }
            }
        });

var app = builder.Build();

// Mapear el Reverse Proxy
app.MapReverseProxy();

app.Run();