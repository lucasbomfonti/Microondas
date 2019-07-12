using Microondas.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Microondas.Services
{
    public class MicrowaveService : IMicrowaveService
    {
        public string Heat(PreHeating microwave)
        {
            var response = PreHeatingValidate(microwave);
            TimeValidate(response.Second);
            PowerValidate(response.Power);
            response.Power = response.Power ?? 10;
            Thread.Sleep((int)response.Second * 1000);
            return "heated!";
        }

        public string FastHeat(PreHeating microwave)
        {
            microwave.Power = 8;
            Thread.Sleep(30000);
            return "heated!";
        }

        public List<PreHeating> GetPreHeating()
        {
            return EnvironmentProperties.PreHeatings;
        }

        private void TimeValidate(decimal? second)
        {
            if (!second.HasValue || second.HasValue && second < 1 || second > 120)
                throw new InvalidDataException("Digite um valor entre 1 a 120 segundos.");
        }

        private void PowerValidate(int? power)
        {
            if (power.HasValue && power > 10)
                throw new InvalidDataException("Potência inválida. Digite um valor entre 1 e 10");
        }

        private PreHeating PreHeatingValidate(PreHeating preHeating)
        {
            if (string.IsNullOrEmpty(preHeating.KeyText))
                return preHeating;
            return EnvironmentProperties.PreHeatings.FirstOrDefault(f => f.KeyText.Equals(preHeating.KeyText.ToUpper()));
        }
    }
}