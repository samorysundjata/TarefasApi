using Dapper.Contrib.Extensions;
using TarefasApi.Data;
using static TarefasApi.Data.TarefaContext;

namespace TarefasApi.Endpoints
{
    public static class TarefasEndpoint
    {
        public static void MapTarefasEndpoint(this WebApplication app)
        {
            app.MapGet("/", () => $"Bem-vindo a API Tarefas {DateTime.Now}");

            app.MapGet("/tarefas", async(GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tarefas = con.GetAll<Tarefa>().ToList();

                if (tarefas is null)
                    return Results.NotFound();

                return Results.Ok(tarefas);
            });
        }
    }
}
