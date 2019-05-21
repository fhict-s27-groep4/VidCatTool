using System.Collections.Generic;
using System.Threading.Tasks;
using Model_Layer.Interface;

namespace Logic_Layer.JsonWriter
{
    public interface IWriterJson
    {
        Task<string> Write(IEnumerable<IDuncan> _ratings);
    }
}