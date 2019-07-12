using Microondas.Helpers;
using Microondas.Models;
using Microondas.Services;
using NUnit.Framework;
using System;
using Microondas.Runner;

namespace Microondas.Test.ServicesTest
{
    [TestFixture]
    public class MicrowaveServiceTest
    {
        private IMicrowaveService _service;

        [SetUp]
        public void Setup()
        {
            _service = new MicrowaveService();
        }

        [Test, Order(1)]
        public void Deve_validar_um_aquecimento_assertivo()
        {
            var temp = _service.Heat(new PreHeating
            {
                KeyText = null,
                Second = 2,
                Power = 2,
                Id = Guid.NewGuid()
            });
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp, "heated!");
        }

        [Test, Order(2)]
        public void Deve_retorar_uma_excecao_devido_a_tempo_invalido()
        {
            var temp = new PreHeating
            {
                KeyText = null,
                Second = 0,
                Power = 2,
                Id = Guid.NewGuid()
            };
            Assert.Throws<EntityValidationException>(() => _service.Heat(temp));
        }

        [Test, Order(3)]
        public void Deve_retorar_uma_excecao_devido_a_potencia_invalida()
        {
            var temp = new PreHeating
            {
                KeyText = null,
                Second = 3,
                Power = -1,
                Id = Guid.NewGuid()
            };
            Assert.Throws<EntityValidationException>(() => _service.Heat(temp));
        }

        [Test, Order(4)]
        public void Deve_validar_um_aquecimento_rapido_assertivo()
        {
            var temp = _service.FastHeat(new PreHeating());
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp, "heated!");
        }

        [Test, Order(5)]
        public void Deve_retornar_todas_funcoes_de_pre_aquecimento()
        {
            PreHeatingSeed.Seed();
            var temp = _service.GetPreHeating();
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.Count, 5);
        }
    }
}