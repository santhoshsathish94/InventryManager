using AutoMapper;
using InventryManager.API.Models;

namespace InventryManager.API.Middleware
{
    public class ReponseHandler
    {
        private readonly IMapper _mapper;
        public ReponseHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ResponseModel<T> CreateResponse<T, U>(IEnumerable<U> results) 
        {
            var response = new ResponseModel<T>();
            response.Data = _mapper.Map<IEnumerable<T>>(results);
            return response;
        }
    }
}
