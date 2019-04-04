using System.Threading.Tasks;
using Bookish.Worker.Domain.EntityDomain;

namespace Bookish.Worker.Domain.BusinessDomain.Foo.Interface
{
    public interface IFooBusiness
    {
         Task ShowGreeting(FooEntity entity);
    }
}