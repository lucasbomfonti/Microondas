using Microondas.Models;
using System.Collections.Generic;

namespace Microondas.Services
{
    public interface IMicrowaveService
    {
        string Heat(PreHeating microwave);

        string FastHeat(PreHeating microwave);

        List<PreHeating> GetPreHeating();
    }
}