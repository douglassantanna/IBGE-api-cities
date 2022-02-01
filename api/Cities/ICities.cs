using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cities
{
    public interface ICities
    {
        Task<List<City>> Get();
    }
}