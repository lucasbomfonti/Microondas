using Microondas.Models;
using System;
using System.Collections.Generic;

namespace Microondas.Runner
{
    public static class PreHeatingSeed
    {
        public static void Seed()
        {
            EnvironmentProperties.PreHeatings.AddRange(new List<PreHeating>
           {
               new PreHeating
               {
                   Second = 20,
                   Instruction = "Pré aquecimento programado para frango",
                   Power = 4,
                   Id = Guid.NewGuid(),
                   KeyText = "FRANGO",
               },
               new PreHeating
               {
                   Second = 100,
                   Instruction = "Pré aquecimento programado para pizza",
                   Power = 5,
                   Id = Guid.NewGuid(),
                   KeyText = "PIZZA",
               },
               new PreHeating
               {
                   Second = 4,
                   Instruction = "Pré aquecimento programado para pipoca",
                   Power = 6,
                   Id = Guid.NewGuid(),
                   KeyText = "PIPOCA",
               },
               new PreHeating
               {
                   Second = 120,
                   Instruction = "Pré aquecimento programado para descongelar alimentos",
                   Power = 10,
                   Id = Guid.NewGuid(),
                   KeyText = "DESCONGELAR",
               },
               new PreHeating
               {
                   Second = 80,
                   Instruction = "Pré aquecimento programado para lasanha",
                   Power = 9,
                   Id = Guid.NewGuid(),
                   KeyText = "LASANHA",
               }
           });
        }
    }
}