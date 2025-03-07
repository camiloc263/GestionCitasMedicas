using CitasMedicas.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CitasMedicas.Application.Services
{
	public class PersonaClient
	{
        private readonly HttpClient httpClient;
        private readonly string _baseUrl = "https://localhost:44381/api/persona"; 

        public PersonaClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PersonaDto> GetPersonaByDocumento(string numeroDocumento)
        {
            var response = await httpClient.GetAsync($"{_baseUrl}/buscar/{numeroDocumento}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PersonaDto>(content);
        }
    }
}