using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Builders
{
    public class Builder
    {

        public static Faker Faker = new Faker();

        public void SobrescreverPropriedadePrivada<T, U>(T objeto, string propriedade, T valor) where T : struct where U : struct
        {
            PropertyInfo propertyInfo = objeto.GetType().GetProperty(propriedade);
            if (propertyInfo == null) return;
            propertyInfo.SetValue(objeto, valor);
        }

    }
}
