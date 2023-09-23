using Microsoft.AspNetCore.Mvc;
using Part1.Shared.Request;
using Part1.Shared.Response;
using Part1Api.Library;

namespace Part1Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CalculoController : ControllerBase
    {

        public CalculoController() { }

        [HttpGet("Decompor")]
        public Response<List<int>> Decompor(int numero)
        {
            Response<List<int>> response = new();

            if (numero == int.MaxValue) 
            {
                response.Data = null;
                response.Sucess = false;
                response.Message = "Número muito grande";
                return response;
            }

            try
            {
                var resultado = Matematica.Decompor(numero);
                response.Data = resultado;
                response.Sucess = true;
            }
            catch(Exception ex) 
            {
                response.Data = null;
                response.Sucess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("RemoverNumerosNaoPrimos")]
        public Response<List<int>> RemoverNumerosNaoPrimos(RemoverNumerosNaoPrimosRequest request)
        {
            Response<List<int>> response = new();
            try
            {
                var resultado = Matematica.RemoverNumerosNaoPrimos(request.Numeros                                                                         );
                response.Data = resultado;
                response.Sucess = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Sucess = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}