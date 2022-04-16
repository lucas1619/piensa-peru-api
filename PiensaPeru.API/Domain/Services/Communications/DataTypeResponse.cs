using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class DataTypeResponse : BaseResponse<DataType>
    {
        public DataTypeResponse(DataType resource) : base(resource)
        {
        }

        public DataTypeResponse(string message) : base(message)
        {
        }
    }
}
