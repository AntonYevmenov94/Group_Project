using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Services
{
    /// <summary>
    /// <para>Сервис для доступа к IoC контейнеру из любого места программы.
    /// Использовать только в случае необходимости.</para>
    /// Для резолва компонентов использовать <see cref="Autofac.ILifetimeScope"/>
    /// </summary>
    public static class IoCContainerProvider
    {
        public static IContainer Container { get; set; }
    }
}
